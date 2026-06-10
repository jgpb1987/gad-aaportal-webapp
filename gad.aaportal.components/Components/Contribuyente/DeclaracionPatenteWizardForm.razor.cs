using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace gad.aaportal.components.Components.Contribuyente
{
    public partial class DeclaracionPatenteWizardForm : ComponentBase
    {
        private PeriodoDeclaracionListResult _periodosDeclaracion = new();
        private IniciarDeclaracionDtoParam _periodoSeleccionado = new();
        private IniciarDeclaracionDtoResult? _declaracionIniciada;

        private List<ContribuyenteEstablecimientoPago> _establecimientos = new();
        private List<ContribuyenteEstablecimientoPago> _establecimientosBase = new();

        private bool _declaracionCalculada;

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
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISpMunicipioConsumers SpMunicipioConsumers { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        private bool _mostrarModalConfirmarValores;
        private bool _mostrarModalComprobante;
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
                        result.Data.PeriodosDeclaracion = result.Data.PeriodosDeclaracion.Where(p => p.AnioEjercicioFiscal == resultaAnioDeclaracion.Data.Anio).ToList();
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
                    .FirstOrDefault(p => p.AnioEjercicioFiscal == _periodoSeleccionado.AnioDeclaracion);

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

                var consultaFechaVencimiento = await SpMunicipioConsumers.ConsultarFechaVencimiento(new ConsultaAnioVencimientoDtoParam() { Anio = periodo.AnioEjercicioFiscal, Ruc = identificacion });
                string fechaStr = $"{consultaFechaVencimiento.Data.Parametro}{periodo.AnioEjercicioFiscal}";
                DateTime fecha = DateTime.ParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                FechaVencimiento = fecha;

                _valoresSugeridos = periodo;

                _valoresDeclaracion = new PeriodoDeclaracionDtoResult
                {
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
                    AnioDeclaracion = periodo.AnioEjercicioFiscal + 1,
                    EjercicioFiscal = periodo.AnioEjercicioFiscal
                };

                _declaracionIniciada = new IniciarDeclaracionDtoResult
                {
                    Identificacion = identificacion,
                    AnioDeclaracion = periodo.AnioEjercicioFiscal + 1,
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

            var ejercicioFiscalSeleccionado = _declaracionIniciada.EjercicioFiscal;

            var ejercicioFiscalPendienteMenor = _periodosDeclaracion.PeriodosDeclaracion
                .Where(p => p.AnioEjercicioFiscal < ejercicioFiscalSeleccionado)
                .OrderBy(p => p.AnioEjercicioFiscal)
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

        private decimal TotalPatentePorEstablecimientos =>
            _establecimientos.Sum(e => e.Valor);

        private async Task CalcularPatentePorEstablecimientos()
        {
            // Cálculo local de referencia, solo para pruebas:
            try
            {
                foreach (var item in _establecimientos)
                {
                    if (item.Porcentaje > 0 || item.EsMunicipioBase)
                    {
                        item.BaseImponible = Math.Round(BaseImponible * (item.Porcentaje / 100), 2, MidpointRounding.AwayFromZero);
                        var result = await SpMunicipioConsumers.CalcularImpuestoPatente(new CalcularImpuestoPatenteDtoParam { BaseImponible = item.BaseImponible });
                        item.Valor = result.Data.ValorImpuesto;
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }

            await Task.CompletedTask;
        }
        private async Task CalcularUnoCincoPorMil()
        {
            try
            {
                if (BaseImponible != 0)
                {
                    var result = await SpMunicipioConsumers.CalcularImpuestoIat(new CalcularImpuestoIatDtoParam() { BaseImponible = BaseImponible });
                    if (result != null)
                    {
                        if (result.Data != null)
                        {
                            ValorUnoCincoPorMil = result.Data.ImpuestoIat;
                        }
                        else
                        {
                            await MostrarMensaje("error", result.Message.Code, result.Message.Description);
                        }
                    }
                    else
                    {
                        await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
            await Task.CompletedTask;
        }
        private void CargarResumenImpuestos()
        {
            _resumen = new ResumenImpuestoDeclaracionViewModel
            {
                Patrimonio = Patrimonio,
                DerechoPatenteAnual = TotalPatentePorEstablecimientos,
                ValoresBomberosPatente = ValorBomberos,
                MultaPatente = ValorMultaPatente,
                DescuentoPatenteTerceraEdad = 0,

                TotalPatentePagar =
                    TotalPatentePorEstablecimientos +
                    ValorMultaPatente +
                    ValorBomberos,

                BaseImponible1_5_x_1000 = BaseImponible,
                ImpuestoActivos = ValorUnoCincoPorMil,
                Multa15 = ValorMultaPorMil,
                DescuentoTerceraEdad15 = 0,

                Total15Pagar =
                    ValorUnoCincoPorMil +
                    ValorMultaPorMil,
            };

            _resumen.TotalPagar =
                _resumen.TotalPatentePagar +
                _resumen.Total15Pagar;
        }
        private async Task CalcularDeclaracion()
        {
            try
            {
                if (!_establecimientos.Any())
                {
                    _declaracionCalculada = false;
                    await MostrarMensaje(
                        "error",
                        "DEC006",
                        "No existen establecimientos para calcular la distribución cantonal");

                    return;
                }

                if (SumaPorcentaje != 100)
                {
                    _declaracionCalculada = false;
                    await MostrarMensaje(
                        "error",
                        "DEC007",
                        "La suma de porcentajes de distribución cantonal debe ser 100%");

                    return;
                }

                LoadingBorder?.Open();

                #region Calculo valores patente sp municipio
                await CalcularPatentePorEstablecimientos();
                await CalcularUnoCincoPorMil();
                await ConsultarValorBomberos();
                #endregion

                #region Calculo multa sp municipio
                await CalcularMultaPatente();
                await CalcularMulta1_5Mil();
                #endregion

                CargarResumenImpuestos();

                await CalcularValoresTerceraEdadPatente();
                await CalcularValoresTerceraEdad_1_5Mil();

                LoadingBorder?.Close();

                _declaracionCalculada = true;
                StateHasChanged();

                await MostrarMensaje(
                    "success",
                    "DEC008",
                    "Declaración calculada correctamente");
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
                    Anio = _declaracionIniciada.EjercicioFiscal,

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
                    PorcentajeDescuentoTerceraEdadPatente = PorcentajeDescuentoTerceraEdadPatente,
                    PorcentajeDescuentoTerceraEdadIAT = PorcentajeDescuentoTerceraEdadIAT,
                    PorcentajeCalculoIat = _establecimientosBase.FirstOrDefault().Porcentaje,
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
        private async Task CalcularMultaPatente()
        {
            try
            {
                var fechaActual = DateTime.Today;
                if (BaseImponible != 0)
                {
                    var result = await SpMunicipioConsumers.CalcularMulta(
                        new CalcularMultaDtoParam()
                        {
                            PeriodoFin = FechaVencimiento.ToString("yyyy-MM-dd"),
                            FechaEmision = fechaActual.ToString("yyyy-MM-dd"),
                            Valor = BaseImponible
                        });
                    if (result != null)
                    {
                        if (result.Data != null)
                        {
                            ValorMultaPatente = result.Data.Multa;
                        }
                        else
                        {
                            await MostrarMensaje("error", result.Message.Code, result.Message.Description);
                        }
                    }
                    else
                    {
                        await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
            await Task.CompletedTask;
        }
        private async Task CalcularMulta1_5Mil()
        {
            try
            {
                var fechaActual = DateTime.Today;
                if (BaseImponible != 0)
                {
                    var result = await SpMunicipioConsumers.CalcularMulta(
                                          new CalcularMultaDtoParam()
                                          {
                                              PeriodoFin = new DateTime(
                                                  _periodoSeleccionado.AnioDeclaracion,
                                                  fechaActual.Month,
                                                  fechaActual.Day
                                              ).ToString("yyyy-MM-dd"),
                                              FechaEmision = fechaActual.ToString("yyyy-MM-dd"),
                                              Valor = BaseImponible
                                          });
                    if (result != null)
                    {
                        if (result.Data != null)
                        {
                            ValorMultaPorMil = result.Data.Multa;
                        }
                        else
                        {
                            await MostrarMensaje("error", result.Message.Code, result.Message.Description);
                        }
                    }
                    else
                    {
                        await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
            await Task.CompletedTask;
        }
        #endregion

        #region Cálculo tercera edad
        private async Task CalcularValoresTerceraEdadPatente()
        {
            try
            {
                var fechaActual = DateTime.Today;
                if (BaseImponible != 0)
                {
                    var result = await SpMunicipioConsumers.CalcularTerceraEdad(new CalcularTerceraEdadDtoParam() { BasePatrimonio = (_valoresDeclaracion.ActivoCorriente + _valoresDeclaracion.ActivoNoCorriente) - (_valoresDeclaracion.PasivoCorriente + _valoresDeclaracion.PasivoNoCorriente + _valoresDeclaracion.PasivoContingente), Anio = _periodoSeleccionado.AnioDeclaracion, Ingresos = _valoresDeclaracion.Ingresos, Ruc = _periodoSeleccionado.Identificacion, TipoImpuesto = "PMA", ValorImpuesto = TotalPatentePorEstablecimientos });
                    if (result != null)
                    {
                        if (result.Message.Code.Equals("OK"))
                        {
                            //await MostrarMensaje("success", result.Message.Code, result.Message.Description);
                            PorcentajeDescuentoTerceraEdadPatente = result.Data.PorcentajeAplicar;
                            ValorExoneradoPatente = result.Data.ValorDescuento;
                            ExedentePatente = result.Data.ExedenteAplicado;
                            PorcentajeIngreso = result.Data.PorcentajeIngresos;
                        }
                        else
                        {
                            await MostrarMensaje("error", result.Message.Code, result.Message.Description);
                        }
                    }
                    else
                    {
                        await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
            await Task.CompletedTask;
        }
        private async Task CalcularValoresTerceraEdad_1_5Mil()
        {
            try
            {
                var fechaActual = DateTime.Today;
                if (BaseImponible != 0)
                {
                    var result = await SpMunicipioConsumers.CalcularTerceraEdad(new CalcularTerceraEdadDtoParam() { BasePatrimonio = (_valoresDeclaracion.ActivoCorriente + _valoresDeclaracion.ActivoNoCorriente) - (_valoresDeclaracion.PasivoCorriente + _valoresDeclaracion.PasivoNoCorriente + _valoresDeclaracion.PasivoContingente), Anio = _periodoSeleccionado.AnioDeclaracion, Ingresos = _valoresDeclaracion.Ingresos, Ruc = _periodoSeleccionado.Identificacion, TipoImpuesto = "IAT", ValorImpuesto = ValorUnoCincoPorMil });
                    if (result != null)
                    {
                        if (result.Message.Code.Equals("OK"))
                        {
                            //await MostrarMensaje("success", result.Message.Code, result.Message.Description);
                            PorcentajeDescuentoTerceraEdadIAT = result.Data.ValorDescuento;
                            ValorExoneradoIAT = result.Data.ValorDescuento;
                            ExedenteIAT = result.Data.ExedenteAplicado;
                            PorcentajeIngreso = result.Data.PorcentajeIngresos;
                        }
                        else
                        {
                            await MostrarMensaje("error", result.Message.Code, result.Message.Description);
                        }
                    }
                    else
                    {
                        await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
            }
            catch
            {
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
            await Task.CompletedTask;
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
        private async Task ConsultarValorBomberos()
        {
            try
            {
                ValorBomberos = 0;

                if (_declaracionIniciada is null ||
                    string.IsNullOrWhiteSpace(_declaracionIniciada.Identificacion))
                    return;

                var result = await SpMunicipioConsumers.ConsultarValorBomberos(
                    new ConsultarValorBomberosDtoParam
                    {
                        Ruc = _declaracionIniciada.Identificacion
                    });

                if (result?.Data is not null)
                {
                    ValorBomberos = Convert.ToDecimal(result.Data.ValorBomberos);
                    return;
                }

                if (result?.Message is not null)
                {
                    await MostrarMensaje(
                        "error",
                        result.Message.Code,
                        result.Message.Description);
                }
            }
            catch
            {
                ValorBomberos = 0;
                await MostrarMensaje("error", "SERVER_ERROR", "Existe un error al consultar el valor de Bomberos");
            }
        }
        #endregion
    }
}
