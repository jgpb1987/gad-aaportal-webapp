using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace gad.aaportal.components.Components.Contribuyente
{
    public partial class DeclaracionPatenteWizardForm : ComponentBase
    {
        private PeriodoDeclaracionListResult _periodosDeclaracion = new();
        private IniciarDeclaracionDtoParam _periodoSeleccionado = new();
        private IniciarDeclaracionDtoResult? _declaracionIniciada;
        private InsertarTranferenciaIatDtoParam insertarTranferenciaIatDto = new();
        private List<ContribuyenteEstablecimientoPago> _establecimientos = new();
        private List<ContribuyenteEstablecimientoPago> _establecimientosBase = new();
        private string[] formaPago = new[] { "Depósito", "Transferencia", "Efectivo" };

        private bool _declaracionCalculada;
        private string _mensajeValidacionCalculo = string.Empty;
        private bool TieneMensajeValidacionCalculo => !string.IsNullOrWhiteSpace(_mensajeValidacionCalculo);
        private CantonesResponse _cantones = new();

        private PeriodoDeclaracionDtoResult _valoresDeclaracion = new();
        private PeriodoDeclaracionDtoResult _valoresSugeridos = new();

        private ResumenImpuestoDeclaracionViewModel _resumen = new();

        private bool _mostrarModalPeriodo;
        private int _stepActual = 1;
        private bool _procesoFinalizado;
        private bool _tieneRestriccionMunicipal;
        private string _mensajeRestriccionMunicipal = string.Empty;
        private DateTime FechaVencimiento;
        private decimal PorcentajeDescuentoTerceraEdadPatente = 0;
        private decimal PorcentajeDescuentoTerceraEdadIAT = 0;
        private decimal ValorExoneradoPatente = 0;
        private decimal ValorExoneradoIAT = 0;
        private decimal PorcentajeIngreso = 0;
        private string ExedentePatente = string.Empty;
        private string ExedenteIAT = string.Empty;

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesDeclaracion { get; set; } = null!;
        [Inject] private IConsultaServices ConsultaServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISpMunicipioConsumers SpMunicipioConsumers { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        private bool _mostrarModalConfirmarValores;
        private bool _mostrarModalComprobante;
        private bool _mostrarModalPagoOtroCanton;
        private RegistrarDeclaracionDtoResult? _declaracionRegistrada;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await CargarPeriodosDeclaracion();
        }
        private List<ContribuyenteEstablecimientoPago> ClonarEstablecimientos(List<ContribuyenteEstablecimientoPago> establecimientos)
        {
            return establecimientos.Select(e => new ContribuyenteEstablecimientoPago
            {
                Provincia = e.Provincia,
                Canton = e.Canton,
                BaseImponible = e.BaseImponible,
                Porcentaje = e.Porcentaje,
                Valor = e.Valor,
                AplicaPago = e.AplicaPago,
                EsMunicipioBase = e.EsMunicipioBase
            }).ToList();
        }
        private async Task CargarPeriodosDeclaracion()
        {
            try
            {
                LoadingBorder?.Open();

                var usuario = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Identificacion);
                var parametro = new ContribuyenteDtoParam { Identificacion = usuario };
                var result = await ServicesDeclaracion.ConsultarPeriodosDeclaracion(parametro);
                #region consultar anio adeuda
                var resultaAnioDeclaracion = await SpMunicipioConsumers.ConsultarAnioAdeuda(new ConsultarAnioAdeudaDtoParam() { Ruc = usuario });
                #endregion
                LoadingBorder?.Close();

                if (result?.Data is not null)
                {
                    if (resultaAnioDeclaracion?.Data is not null)
                    {
                        result.Data.PeriodosDeclaracion = result.Data.PeriodosDeclaracion.Where(p => p.AnioPatente == resultaAnioDeclaracion.Data.Anio).ToList();                      
                        _periodosDeclaracion = result.Data;                       
                        _establecimientosBase = ClonarEstablecimientos(_periodosDeclaracion.Establecimientos ?? new List<ContribuyenteEstablecimientoPago>());
                        StateHasChanged();
                    }
                    else
                    {
                        await MostrarMensaje("error",
                        result?.Message?.Code ?? "PERIODOS",
                        result?.Message?.Description ?? "No existen periodos a declarar en el Municipio");
                    }
                }
                else
                {
                    await MostrarMensaje(
                        "error",
                        result?.Message?.Code ?? "PERIODOS_ERROR",
                        result?.Message?.Description ?? "No fue posible consultar los períodos de declaración");
                }
            }
            catch
            {
                LoadingBorder?.Close();
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
        private async Task AbrirModalPeriodo()
        {
            var identificacion = await JSSessionStorageServices
                .GetItemAsync(Configuraciones.AppConfig.Identificacion);

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                await MostrarMensaje("error", "IDENTIFICACION_NO_ENCONTRADA", "No se encontró la identificación del contribuyente en sesión");
                return;
            }

            LoadingBorder?.Open();

            var puedeDeclarar = await ValidarRestriccionesMunicipales(identificacion);

            LoadingBorder?.Close();

            if (!puedeDeclarar)
                return;

            _periodoSeleccionado = new IniciarDeclaracionDtoParam
            {
                Identificacion = identificacion
            };

            _mostrarModalPeriodo = true;
        }

        private void CerrarModalPeriodo()
        {
            _mostrarModalPeriodo = false;
        }

        private async Task ConfirmarPeriodo()
        {
            try
            {
                var periodo = _periodosDeclaracion.PeriodosDeclaracion
                    .FirstOrDefault(p => p.AnioPatente == _periodoSeleccionado.AnioDeclaracion);

                if (periodo == null)
                {
                    await MostrarMensaje("error", "DEC005", "Debe seleccionar un período válido");
                    return;
                }

                var identificacion = await JSSessionStorageServices
                    .GetItemAsync(Configuraciones.AppConfig.Identificacion);

                if (string.IsNullOrWhiteSpace(identificacion))
                {
                    await MostrarMensaje("error", "IDENTIFICACION_NO_ENCONTRADA", "No se encontró la identificación del contribuyente en sesión");
                    return;
                }
                var puedeDeclarar = await ValidarRestriccionesMunicipales(identificacion);

                if (!puedeDeclarar)
                {
                    _mostrarModalPeriodo = false;
                    return;
                }

                var consultaFechaVencimiento = await SpMunicipioConsumers.ConsultarFechaVencimiento(new ConsultaAnioVencimientoDtoParam() { Anio = periodo.AnioPatente, Ruc = identificacion });
                string fechaStr = $"{consultaFechaVencimiento.Data.Parametro}{periodo.AnioPatente}";
                DateTime fecha = DateTime.ParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                FechaVencimiento = fecha;

                _valoresSugeridos = periodo;

                _valoresDeclaracion = new PeriodoDeclaracionDtoResult
                {
                    AnioPatente = periodo.AnioPatente,
                    AnioEjercicioFiscal = periodo.AnioEjercicioFiscal,
                    Descripcion = periodo.Descripcion,
                    ActivoCorriente = periodo.ActivoCorriente,
                    ActivoNoCorriente = periodo.ActivoNoCorriente,
                    PasivoCorriente = periodo.PasivoCorriente,
                    PasivoNoCorriente = periodo.PasivoNoCorriente,
                    PasivoContingente = periodo.PasivoContingente,
                    Ingresos = periodo.Ingresos,
                    CostosGastos = periodo.CostosGastos
                };

                _periodoSeleccionado = new IniciarDeclaracionDtoParam
                {
                    Identificacion = identificacion,
                    AnioDeclaracion = periodo.AnioPatente,
                    EjercicioFiscal = periodo.AnioEjercicioFiscal
                };

                _declaracionIniciada = new IniciarDeclaracionDtoResult
                {
                    Identificacion = identificacion,
                    AnioDeclaracion = periodo.AnioPatente,
                    EjercicioFiscal = periodo.AnioEjercicioFiscal,
                    DescripcionPeriodo = periodo.Descripcion
                };

                _establecimientos = ClonarEstablecimientos(_establecimientosBase);

                ValorUnoCincoPorMil = 0;
                _stepActual = 1;
                _declaracionCalculada = false;
                _mostrarModalPeriodo = false;

                StateHasChanged();
            }
            catch
            {
                LoadingBorder?.Close();
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
        private async Task<bool> ValidarOrdenDeclaracion()
        {
            if (_declaracionIniciada is null)
            {
                await MostrarMensaje(
                    "error",
                    "DEC009",
                    "No existe una declaración iniciada");

                return false;
            }

            if (_periodosDeclaracion?.PeriodosDeclaracion is null ||
                !_periodosDeclaracion.PeriodosDeclaracion.Any())
            {
                await MostrarMensaje(
                    "error",
                    "DEC010",
                    "No existen períodos disponibles para validar la declaración");

                return false;
            }

            var ejercicioFiscalSeleccionado = _declaracionIniciada.AnioDeclaracion;

            var ejercicioFiscalPendienteMenor = _periodosDeclaracion.PeriodosDeclaracion
                .Where(p => p.AnioPatente < ejercicioFiscalSeleccionado)
                .OrderBy(p => p.AnioPatente)
                .FirstOrDefault();

            if (ejercicioFiscalPendienteMenor is not null)
            {
                await MostrarMensaje(
                    "error",
                    "DEC011",
                    $"No puede continuar con la declaración del ejercicio fiscal {ejercicioFiscalSeleccionado}. Primero debe declarar el ejercicio fiscal {ejercicioFiscalPendienteMenor.AnioEjercicioFiscal}.");

                return false;
            }

            return true;
        }
        private async Task SiguienteStep()
        {
            if (_stepActual == 1)
            {
                if (!await ValidarOrdenDeclaracion())
                    return;
            }

            if (_stepActual < 3)
                _stepActual++;
        }
        //private void SiguienteStep()
        //{

        //    if (_stepActual < 3)
        //        _stepActual++;
        //}

        private void AnteriorStep()
        {
            if (_stepActual > 1)
                _stepActual--;
        }

        private string ObtenerClaseStep(int step)
        {
            if (_stepActual == step)
                return "wizard-step active";

            if (_stepActual > step)
                return "wizard-step completed";

            return "wizard-step";
        }

        private async Task MostrarMensaje(string tipo, string codigo, string descripcion)
        {
            if (Toast is not null)
                await Toast.ShowMessage(tipo, codigo, descripcion);
        }
        private async Task MarcarCalculoNoValido(string codigo, string descripcion)
        {
            _declaracionCalculada = false;
            _mensajeValidacionCalculo = descripcion;

            LoadingBorder?.Close();

            await MostrarMensaje(
                "error",
                codigo,
                descripcion);

            StateHasChanged();
        }

        private void InvalidarCalculo()
        {
            _declaracionCalculada = false;
            _mensajeValidacionCalculo = string.Empty;

            ValorUnoCincoPorMil = 0;
            ValorMultaPatente = 0;
            ValorMultaPorMil = 0;
            ValorBomberos = 0;

            InteresPatente = 0;
            RecargoPatente = 0;
            CostasPatente = 0;
            TasaAdministrativaPatente = 0;

            InteresIat = 0;
            RecargoIat = 0;
            CostasIat = 0;
            TasaAdministrativaIat = 0;

            ValorExoneradoPatente = 0;
            ValorExoneradoIAT = 0;
            PorcentajeDescuentoTerceraEdadPatente = 0;
            PorcentajeDescuentoTerceraEdadIAT = 0;

            foreach (var item in _establecimientos)
            {
                item.Valor = 0;
                item.BaseImponible = 0;
            }

            _resumen = new ResumenImpuestoDeclaracionViewModel();
        }
        private decimal TotalActivo =>
    _valoresDeclaracion.ActivoCorriente + _valoresDeclaracion.ActivoNoCorriente;

        private decimal TotalPasivo =>
            _valoresDeclaracion.PasivoCorriente +
            _valoresDeclaracion.PasivoNoCorriente +
            _valoresDeclaracion.PasivoContingente;

        private decimal Patrimonio =>
            TotalActivo - TotalPasivo;

        private decimal BaseImponible =>
            (TotalActivo - _valoresDeclaracion.PasivoCorriente) > 0 ? (TotalActivo - _valoresDeclaracion.PasivoCorriente) : 0;

        private decimal UtilidadEjercicio =>
            _valoresDeclaracion.Ingresos > _valoresDeclaracion.CostosGastos
                ? _valoresDeclaracion.Ingresos - _valoresDeclaracion.CostosGastos
                : 0;

        private decimal PerdidaEjercicio =>
            _valoresDeclaracion.CostosGastos > _valoresDeclaracion.Ingresos
                ? _valoresDeclaracion.CostosGastos - _valoresDeclaracion.Ingresos
                : 0;

        private decimal SumaPorcentaje =>
            _establecimientos.Sum(e => e.Porcentaje);

        private decimal ValorUnoCincoPorMil { get; set; }
        private decimal ValorMultaPorMil { get; set; }
        private decimal ValorMultaPatente { get; set; }
        private decimal ValorBomberos { get; set; }
        private bool MostrarValorBomberos => ValorBomberos > 0;
        private decimal Valores3EdadPatente { get; set; }
        private decimal Valores3EdadPorMil { get; set; }
        private decimal InteresPatente { get; set; }
        private decimal RecargoPatente { get; set; }
        private decimal CostasPatente { get; set; }
        private decimal TasaAdministrativaPatente { get; set; }

        private decimal InteresIat { get; set; }
        private decimal RecargoIat { get; set; }
        private decimal CostasIat { get; set; }
        private decimal TasaAdministrativaIat { get; set; }
        private decimal TotalPatentePorEstablecimientos =>
            _establecimientos.Sum(e => e.Valor);

        private async Task<bool> CalcularPatentePorEstablecimientos()
        {
            try
            {
                foreach (var item in _establecimientos)
                {
                    if (item.Porcentaje > 0 || item.EsMunicipioBase)
                    {
                        item.BaseImponible = Math.Round(
                            Patrimonio * (item.Porcentaje / 100),
                            2,
                            MidpointRounding.AwayFromZero);

                        var result = await SpMunicipioConsumers.CalcularImpuestoPatente(
                            new CalcularImpuestoPatenteDtoParam
                            {
                                BaseImponible = item.BaseImponible,
                                Ingresos = _valoresDeclaracion.Ingresos
                            });

                        if (result?.Data is null)
                        {
                            await MarcarCalculoNoValido(
                                result?.Message?.Code ?? "PATENTE_ERROR",
                                result?.Message?.Description ?? "No fue posible calcular el impuesto de patente");

                            return false;
                        }

                        item.Valor = result.Data.ValorImpuesto;
                    }
                }

                return true;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular el impuesto de patente");

                return false;
            }
        }
        private async Task<bool> CalcularUnoCincoPorMil()
        {
            try
            {
                ValorUnoCincoPorMil = 0;

                if (BaseImponible == 0)
                    return true;

                var result = await SpMunicipioConsumers.CalcularImpuestoIat(
                    new CalcularImpuestoIatDtoParam
                    {
                        BaseImponible = BaseImponible
                    });

                if (result?.Data is null)
                {
                    await MarcarCalculoNoValido(
                        result?.Message?.Code ?? "IAT_ERROR",
                        result?.Message?.Description ?? "No fue posible calcular el impuesto 1.5 x 1000");

                    return false;
                }

                ValorUnoCincoPorMil = result.Data.ImpuestoIat;
                return true;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular el impuesto 1.5 x 1000");

                return false;
            }
        }
        private void CargarResumenImpuestos()
        {
            var totalAdicionalesPatente =
                InteresPatente +
                RecargoPatente +
                CostasPatente +
                TasaAdministrativaPatente;

            var totalAdicionalesIat =
                InteresIat +
                RecargoIat +
                CostasIat +
                TasaAdministrativaIat;

            var totalDescuentoPatente = ValorExoneradoPatente;
            var totalDescuentoIat = ValorExoneradoIAT;

            _resumen = new ResumenImpuestoDeclaracionViewModel
            {
                Patrimonio = Patrimonio,

                DerechoPatenteAnual = TotalPatentePorEstablecimientos,
                ValoresBomberosPatente = ValorBomberos,
                MultaPatente = ValorMultaPatente,
                DescuentoPatenteTerceraEdad = totalDescuentoPatente,

                TotalPatentePagar =
                    TotalPatentePorEstablecimientos +
                    ValorMultaPatente +
                    ValorBomberos +
                    totalAdicionalesPatente -
                    totalDescuentoPatente,

                BaseImponible1_5_x_1000 = BaseImponible,
                ImpuestoActivos = ValorUnoCincoPorMil,
                Multa15 = ValorMultaPorMil,
                DescuentoTerceraEdad15 = totalDescuentoIat,

                Total15Pagar =
                    ValorUnoCincoPorMil +
                    ValorMultaPorMil +
                    totalAdicionalesIat -
                    totalDescuentoIat
            };

            _resumen.TotalPagar =
                _resumen.TotalPatentePagar +
                _resumen.Total15Pagar;
        }
        private async Task CalcularDeclaracion()
        {
            try
            {
                _declaracionCalculada = false;
                _mensajeValidacionCalculo = string.Empty;

                if (!_establecimientos.Any())
                {
                    await MarcarCalculoNoValido(
                        "DEC006",
                        "No existen establecimientos para calcular la distribución cantonal");

                    return;
                }

                if (SumaPorcentaje != 100)
                {
                    await MarcarCalculoNoValido(
                        "DEC007",
                        "La suma de porcentajes de distribución cantonal debe ser 100%");

                    return;
                }

                if (_declaracionIniciada is null)
                {
                    await MarcarCalculoNoValido(
                        "DEC010",
                        "No existe una declaración iniciada");

                    return;
                }

                LoadingBorder?.Open();

                var parametros = new ConsultarRucExoneracionesDtoParam
                {
                    Ruc = _periodoSeleccionado.Identificacion
                };

                var exoneraciones = await SpMunicipioConsumers.ConsultarRucExoneraciones(parametros);

                if (exoneraciones?.Data is null)
                {
                    await MarcarCalculoNoValido(
                        exoneraciones?.Message?.Code ?? "EXONERACION_ERROR",
                        exoneraciones?.Message?.Description ?? "No fue posible consultar las exoneraciones del contribuyente");

                    return;
                }

                if (exoneraciones.Data.ExoneracionPatente == "SiPaga")
                {
                    if (!await CalcularPatentePorEstablecimientos())
                        return;
                }
                else if (exoneraciones.Data.ExoneracionPatente == "NoPaga")
                {
                    foreach (var item in _establecimientos)
                    {
                        item.Valor = 0;
                    }
                }

                if (exoneraciones.Data.ExoneracionIat == "SiPaga")
                {
                    if (!await CalcularUnoCincoPorMil())
                        return;
                }
                else if (exoneraciones.Data.ExoneracionIat == "NoPaga")
                {
                    ValorUnoCincoPorMil = 0;
                }

                if (!await ConsultarValorBomberos())
                    return;

                if (!await CalcularMultaPatente())
                    return;

                if (!await CalcularMulta1_5Mil())
                    return;

                if (!await ConsultarValoresPagar())
                    return;

                if (!await CalcularValoresTerceraEdadPatente())
                    return;

                if (!await CalcularValoresTerceraEdad_1_5Mil())
                    return;

                CargarResumenImpuestos();

                LoadingBorder?.Close();

                _declaracionCalculada = true;
                _mensajeValidacionCalculo = string.Empty;

                StateHasChanged();

                await MostrarMensaje(
                    "success",
                    "DEC008",
                    "Declaración calculada correctamente");
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
        private async Task AbrirModalConfirmarValores()
        {
            if (!_declaracionCalculada)
            {
                await MostrarMensaje(
                    "error",
                    "DEC009",
                    "Primero debe calcular la declaración antes de confirmar los valores");

                return;
            }

            if (_declaracionIniciada is null)
            {
                await MostrarMensaje(
                    "error",
                    "DEC010",
                    "No existe una declaración iniciada");

                return;
            }

            _mostrarModalConfirmarValores = true;
        }

        private void CerrarModalConfirmarValores()
        {
            _mostrarModalConfirmarValores = false;
        }

        private async Task AceptarConfirmacionValores()
        {
            try
            {
                _mostrarModalConfirmarValores = false;

                if (_declaracionIniciada is null)
                {
                    await MostrarMensaje(
                        "error",
                        "DEC010",
                        "No existe una declaración iniciada");

                    return;
                }

                LoadingBorder?.Open();

                var parametro = new RegistrarDeclaracionDtoParam
                {
                    Identificacion = _declaracionIniciada.Identificacion,
                    Anio = _declaracionIniciada.AnioDeclaracion,

                    ActivoCorriente = _valoresDeclaracion.ActivoCorriente,
                    ActivoNoCorriente = _valoresDeclaracion.ActivoNoCorriente,
                    PasivoCorriente = _valoresDeclaracion.PasivoCorriente,
                    PasivoNoCorriente = _valoresDeclaracion.PasivoNoCorriente,
                    PasivoContingente = _valoresDeclaracion.PasivoContingente,
                    Ingresos = _valoresDeclaracion.Ingresos,
                    CostosGastos = _valoresDeclaracion.CostosGastos,

                    UnoCincoXMil = ValorUnoCincoPorMil,
                    Patente = TotalPatentePorEstablecimientos,
                    ValorBomberos = ValorBomberos,

                    MultaPatente = ValorMultaPatente,
                    BaseImponiblePatente = BaseImponible,
                    MultaIat = ValorMultaPorMil,
                    FechaVencimiento = FechaVencimiento,

                    InteresPatente = InteresPatente,
                    RecargoPatente = RecargoPatente,
                    CostasPatente = CostasPatente,
                    TasaAdministrativaPatente = TasaAdministrativaPatente,

                    InteresIat = InteresIat,
                    RecargoIat = RecargoIat,
                    CostasIat = CostasIat,
                    TasaAdministrativaIat = TasaAdministrativaIat,

                    PorcentajeDescuentoTerceraEdadPatente = PorcentajeDescuentoTerceraEdadPatente,
                    PorcentajeDescuentoTerceraEdadIAT = PorcentajeDescuentoTerceraEdadIAT,
                    PorcentajeCalculoIat = _establecimientosBase.FirstOrDefault()!.Porcentaje,
                    ValorExoneradoPatente = ValorExoneradoPatente,
                    ValorExoneradoIAT = ValorExoneradoIAT,
                    ExedentePatente = ExedentePatente,
                    ExedenteIAT = ExedenteIAT,
                    PorcentajeIngreso = PorcentajeIngreso
                };

                var result = await ServicesDeclaracion.RegistrarDeclaracion(parametro);

                LoadingBorder?.Close();

                if (result?.Data is null)
                {
                    await MostrarMensaje(
                        "error",
                        result?.Message?.Code ?? "DEC011",
                        result?.Message?.Description ?? "No fue posible registrar la declaración");

                    return;
                }

                _declaracionRegistrada = result.Data;

                _procesoFinalizado = true;
                _stepActual = 3;
                StateHasChanged();
                await MostrarMensaje(
                        "success",
                        result.Message.Code,
                        result.Message.Description);
            }
            catch
            {
                LoadingBorder?.Close();

                await MostrarMensaje(
                    "error",
                    "SERVER_ERROR",
                    "Existe un error no administrado, por favor informe a Tecnología");
            }
        }

        private void AbrirModalComprobante()
        {
            if (_declaracionRegistrada is null)
                return;

            _mostrarModalComprobante = true;
        }

        private void CerrarModalComprobante()
        {
            _mostrarModalComprobante = false;
        }

        private void IrConsultaDeclaraciones()
        {
            NavigationManager.NavigateTo("/consulta-declaracion");
        }
        private async Task VolverInicioDeclaracion()
        {
            try
            {
                InteresPatente = 0;
                RecargoPatente = 0;
                CostasPatente = 0;
                TasaAdministrativaPatente = 0;

                InteresIat = 0;
                RecargoIat = 0;
                CostasIat = 0;
                TasaAdministrativaIat = 0;

                ValorMultaPatente = 0;
                ValorMultaPorMil = 0;
                ValorExoneradoPatente = 0;
                ValorExoneradoIAT = 0;
                PorcentajeDescuentoTerceraEdadPatente = 0;
                PorcentajeDescuentoTerceraEdadIAT = 0;

                _mostrarModalPeriodo = false;
                _mostrarModalConfirmarValores = false;
                _mostrarModalComprobante = false;

                _periodoSeleccionado = new IniciarDeclaracionDtoParam();
                _declaracionIniciada = null;

                _valoresDeclaracion = new PeriodoDeclaracionDtoResult();
                _valoresSugeridos = new PeriodoDeclaracionDtoResult();

                _establecimientos = new List<ContribuyenteEstablecimientoPago>();
                _establecimientosBase = new List<ContribuyenteEstablecimientoPago>();

                _resumen = new ResumenImpuestoDeclaracionViewModel();

                ValorUnoCincoPorMil = 0;
                _declaracionCalculada = false;
                _declaracionRegistrada = null;

                _stepActual = 1;
                _procesoFinalizado = false;
                ValorBomberos = 0;

                await CargarPeriodosDeclaracion();

                StateHasChanged();
            }
            catch
            {
                LoadingBorder?.Close();

                await MostrarMensaje(
                    "error",
                    "SERVER_ERROR",
                    "Existe un error no administrado, por favor informe a Tecnología");
            }
        }

        #region Cálculo multas
        private async Task<bool> CalcularMultaPatente()
        {
            try
            {
                ValorMultaPatente = 0;

                var fechaActual = DateTime.Today;

                if (BaseImponible == 0)
                    return true;

                var result = await SpMunicipioConsumers.CalcularMulta(
                    new CalcularMultaDtoParam
                    {
                        Ruc = _periodoSeleccionado.Identificacion,
                        AnioDeclaracion = FechaVencimiento.Year,
                        Valor = TotalPatentePorEstablecimientos
                    });

                if (result?.Data is null)
                {
                    await MarcarCalculoNoValido(
                        result?.Message?.Code ?? "MULTA_PATENTE_ERROR",
                        result?.Message?.Description ?? "No fue posible calcular la multa de patente");

                    return false;
                }

                ValorMultaPatente = result.Data.Multa;
                return true;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular la multa de patente");

                return false;
            }
        }
        private async Task<bool> CalcularMulta1_5Mil()
        {
            try
            {
                ValorMultaPorMil = 0;

                var fechaActual = DateTime.Today;

                if (BaseImponible == 0)
                    return true;

                var result = await SpMunicipioConsumers.CalcularMulta(
                    new CalcularMultaDtoParam
                    {
                        Ruc = _periodoSeleccionado.Identificacion,
                        AnioDeclaracion = _periodoSeleccionado.AnioDeclaracion,
                        Valor = ValorUnoCincoPorMil
                    });

                if (result?.Data is null)
                {
                    await MarcarCalculoNoValido(
                        result?.Message?.Code ?? "MULTA_IAT_ERROR",
                        result?.Message?.Description ?? "No fue posible calcular la multa del 1.5 x 1000");

                    return false;
                }

                ValorMultaPorMil = result.Data.Multa;
                return true;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular la multa del 1.5 x 1000");

                return false;
            }
        }
        #endregion

        #region Cálculo tercera edad
        private async Task<bool> CalcularValoresTerceraEdadPatente()
        {
            try
            {
                PorcentajeDescuentoTerceraEdadPatente = 0;
                ValorExoneradoPatente = 0;
                ExedentePatente = string.Empty;

                if (BaseImponible == 0)
                    return true;

                var basePatrimonio =
                    (_valoresDeclaracion.ActivoCorriente + _valoresDeclaracion.ActivoNoCorriente)
                    - (_valoresDeclaracion.PasivoCorriente
                       + _valoresDeclaracion.PasivoNoCorriente
                       + _valoresDeclaracion.PasivoContingente);

                var result = await SpMunicipioConsumers.CalcularTerceraEdad(
                    new CalcularTerceraEdadDtoParam
                    {
                        BasePatrimonio = basePatrimonio,
                        Anio = _periodoSeleccionado.AnioDeclaracion, //confirmar con Municipio
                        //Anio = _periodoSeleccionado.EjercicioFiscal,
                        Ingresos = _valoresDeclaracion.Ingresos,
                        Ruc = _periodoSeleccionado.Identificacion,
                        TipoImpuesto = "PMA",
                        ValorImpuesto = TotalPatentePorEstablecimientos
                    });

                if (result?.Message?.Code == "OK" && result.Data is not null)
                {
                    PorcentajeDescuentoTerceraEdadPatente = result.Data.PorcentajeAplicar;
                    ValorExoneradoPatente = result.Data.ValorDescuento;
                    ExedentePatente = result.Data.ExedenteAplicado;
                    PorcentajeIngreso = result.Data.PorcentajeIngresos;

                    return true;
                }

                await MarcarCalculoNoValido(
                    result?.Message?.Code ?? "TERCERA_EDAD_PATENTE_ERROR",
                    result?.Message?.Description ?? "No fue posible calcular el descuento de tercera edad para patente");

                return false;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular tercera edad para patente");

                return false;
            }
        }
        private async Task<bool> CalcularValoresTerceraEdad_1_5Mil()
        {
            try
            {
                PorcentajeDescuentoTerceraEdadIAT = 0;
                ValorExoneradoIAT = 0;
                ExedenteIAT = string.Empty;

                if (BaseImponible == 0)
                    return true;

                var basePatrimonio =
                    (_valoresDeclaracion.ActivoCorriente + _valoresDeclaracion.ActivoNoCorriente)
                    - (_valoresDeclaracion.PasivoCorriente
                       + _valoresDeclaracion.PasivoNoCorriente
                       + _valoresDeclaracion.PasivoContingente);

                var result = await SpMunicipioConsumers.CalcularTerceraEdad(
                    new CalcularTerceraEdadDtoParam
                    {
                        BasePatrimonio = basePatrimonio,
                        Anio = _periodoSeleccionado.AnioDeclaracion,//confirmar con Municipio
                        //Anio= _periodoSeleccionado.EjercicioFiscal,
                        Ingresos = _valoresDeclaracion.Ingresos,
                        Ruc = _periodoSeleccionado.Identificacion,
                        TipoImpuesto = "IAT",
                        ValorImpuesto = ValorUnoCincoPorMil
                    });

                if (result?.Message?.Code == "OK" && result.Data is not null)
                {
                    PorcentajeDescuentoTerceraEdadIAT = result.Data.PorcentajeAplicar;
                    ValorExoneradoIAT = result.Data.ValorDescuento;
                    ExedenteIAT = result.Data.ExedenteAplicado;
                    PorcentajeIngreso = result.Data.PorcentajeIngresos;

                    return true;
                }

                await MarcarCalculoNoValido(
                    result?.Message?.Code ?? "TERCERA_EDAD_IAT_ERROR",
                    result?.Message?.Description ?? "No fue posible calcular el descuento de tercera edad para el 1.5 x 1000");

                return false;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al calcular tercera edad para el 1.5 x 1000");

                return false;
            }
        }
        #endregion

        #region Validar Permisos
        private async Task<bool> ValidarRestriccionesMunicipales(string identificacion)
        {
            var tieneRestricciones = await SpMunicipioConsumers.ValidadorPermisos(new ValidadorPermisosDtoParam { Ruc = identificacion });

            if (tieneRestricciones?.Data is not null && tieneRestricciones.Data.Estado == false)
            {
                _tieneRestriccionMunicipal = true;

                _mensajeRestriccionMunicipal =
                    tieneRestricciones.Data.Mensaje ??
                    "Usted mantiene restricciones en el Municipio. Para continuar con la declaración, debe acercarse a las oficinas municipales.";

                await MostrarMensaje("error", "RESTRICCION_MUNICIPAL", _mensajeRestriccionMunicipal);

                StateHasChanged();
                return false;
            }

            _tieneRestriccionMunicipal = false;
            _mensajeRestriccionMunicipal = string.Empty;

            return true;
        }
        #endregion

        #region Valores Bomberos
        private async Task<bool> ConsultarValorBomberos()
        {
            try
            {
                ValorBomberos = 0;

                if (_declaracionIniciada is null ||
                    string.IsNullOrWhiteSpace(_declaracionIniciada.Identificacion))
                    return true;

                var result = await SpMunicipioConsumers.ConsultarValorBomberos(
                    new ConsultarValorBomberosDtoParam
                    {
                        Ruc = _declaracionIniciada.Identificacion
                    });

                if (result?.Data is not null)
                {
                    ValorBomberos = Convert.ToDecimal(result.Data.ValorBomberos);
                    return true;
                }

                await MarcarCalculoNoValido(
                    result?.Message?.Code ?? "BOMBEROS_ERROR",
                    result?.Message?.Description ?? "No fue posible consultar el valor de Bomberos");

                return false;
            }
            catch
            {
                ValorBomberos = 0;

                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al consultar el valor de Bomberos");

                return false;
            }
        }
        #endregion

        #region Calcular valores municipio
        private async Task<bool> ConsultarValoresPagar()
        {
            try
            {
                InteresPatente = 0;
                RecargoPatente = 0;
                CostasPatente = 0;
                TasaAdministrativaPatente = 0;

                InteresIat = 0;
                RecargoIat = 0;
                CostasIat = 0;
                TasaAdministrativaIat = 0;

                if (_declaracionIniciada is null ||
                    string.IsNullOrWhiteSpace(_declaracionIniciada.Identificacion))
                {
                    await MarcarCalculoNoValido(
                        "DEC010",
                        "No existe una declaración iniciada para consultar valores a pagar");

                    return false;
                }

                var resultPatente = await SpMunicipioConsumers.ConsultaValorP(
                    new ConsultaValorPDtoParam
                    {
                        ValorImpuesto = TotalPatentePorEstablecimientos,
                        ValorMulta = ValorMultaPatente,
                        TipoImpuesto = "PMA",
                        Ruc = _declaracionIniciada.Identificacion,
                        AnioDeclaracion = _periodoSeleccionado.AnioDeclaracion
                    });

                if (resultPatente?.Data is not null)
                {
                    InteresPatente = Convert.ToDecimal(resultPatente.Data.Intereses);
                    RecargoPatente = Convert.ToDecimal(resultPatente.Data.Recargo);
                    CostasPatente = Convert.ToDecimal(resultPatente.Data.CostaJ);
                    TasaAdministrativaPatente = Convert.ToDecimal(resultPatente.Data.TasaAdministrativa);
                }
                else
                {
                    await MarcarCalculoNoValido(
                        resultPatente?.Message?.Code ?? "VALORES_PATENTE_ERROR",
                        resultPatente?.Message?.Description ?? "No fue posible consultar los valores a pagar de patente");

                    return false;
                }

                var resultIat = await SpMunicipioConsumers.ConsultaValorP(
                    new ConsultaValorPDtoParam
                    {
                        ValorImpuesto = ValorUnoCincoPorMil,
                        ValorMulta = ValorMultaPorMil,
                        TipoImpuesto = "IAT",
                        Ruc = _declaracionIniciada.Identificacion,
                        AnioDeclaracion = _periodoSeleccionado.AnioDeclaracion
                    });

                if (resultIat?.Data is not null)
                {
                    InteresIat = Convert.ToDecimal(resultIat.Data.Intereses);
                    RecargoIat = Convert.ToDecimal(resultIat.Data.Recargo);
                    CostasIat = Convert.ToDecimal(resultIat.Data.CostaJ);
                    TasaAdministrativaIat = Convert.ToDecimal(resultIat.Data.TasaAdministrativa);
                }
                else
                {
                    await MarcarCalculoNoValido(
                        resultIat?.Message?.Code ?? "VALORES_IAT_ERROR",
                        resultIat?.Message?.Description ?? "No fue posible consultar los valores a pagar del 1.5 x 1000");

                    return false;
                }

                return true;
            }
            catch
            {
                await MarcarCalculoNoValido(
                    "SERVER_ERROR",
                    "Existe un error al consultar los valores a pagar Municipio");

                return false;
            }
        }
        #endregion

        private async Task ImprimirComprobante()
        {
            await JSRuntime.InvokeVoidAsync("imprimirComprobante", "comprobanteImprimir");
        }

        private async Task PagoOtroCanton()
        {
            _mostrarModalPagoOtroCanton = true;
            await ConsultaCantones();
            insertarTranferenciaIatDto = new InsertarTranferenciaIatDtoParam();
            await Task.CompletedTask;
        }

        private async Task CerrarModalPagoOtroCanton()
        {
            _mostrarModalPagoOtroCanton = false;
            await Task.CompletedTask;
        }

        private async Task ConsultaCantones()
        {
            try
            {
                _cantones = await ConsultaServices.ConsultaCantones();
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error al consultar los cantones para pago en otro cantón");
            }
        }
    }
}
