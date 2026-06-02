using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesDeclaracion { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISpMunicipioConsumers SpMunicipioConsumers { get; set; } = null!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

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

                LoadingBorder?.Close();

                if (result?.Data is not null)
                {
                    _periodosDeclaracion = result.Data;
                    _establecimientosBase = ClonarEstablecimientos(_periodosDeclaracion.Establecimientos ?? new List<ContribuyenteEstablecimientoPago>());
                    StateHasChanged();
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

        private void SiguienteStep()
        {
            if (_stepActual < 3)
                _stepActual++;
        }

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
            Patrimonio > 0 ? Patrimonio : 0;

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
                DerechoPatenteAnual = TotalPatentePorEstablecimientos,
                ValoresBomberosPatente = 0,
                DescuentoAnticipoPagadoSri = 0,
                DescuentoPatenteTerceraEdad = 0,
                ReduccionDescensoUtilidad = 0,
                TotalPatentePagar = TotalPatentePorEstablecimientos,
                MultaPatente = 0,

                ImpuestoActivos = ValorUnoCincoPorMil,
                ValoresBomberos1_1000 = 0,
                DescuentoTerceraEdad15 = 0,
                Total15Pagar = ValorUnoCincoPorMil,
                Multa15 = 0
            };

            _resumen.TotalPagar =
                _resumen.TotalPatentePagar +
                _resumen.MultaPatente +
                _resumen.Total15Pagar +
                _resumen.Multa15;
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

                await CalcularPatentePorEstablecimientos();

                await CalcularUnoCincoPorMil();

                CargarResumenImpuestos();

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
    }
}
