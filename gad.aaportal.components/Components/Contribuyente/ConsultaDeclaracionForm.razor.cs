using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Contribuyente
{
    public partial class ConsultaDeclaracionForm : ComponentBase
    {
        private List<ConsultarDeclaracionContribuyenteDtoResult> _declaraciones = new();
        private ConsultarDeclaracionContribuyenteDtoResult? _declaracionSeleccionada;

        private bool _mostrarModalDetalle;
        private DateTime FechaGeneracion;

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesContribuyente { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = null!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await CargarDeclaraciones();
        }

        private async Task CargarDeclaraciones()
        {
            try
            {
                LoadingBorder?.Open();

                FechaGeneracion = DateTime.Now;
                var identificacion = await JSSessionStorageServices
                    .GetItemAsync(Configuraciones.AppConfig.Identificacion);

                if (string.IsNullOrWhiteSpace(identificacion))
                {
                    LoadingBorder?.Close();

                    await MostrarMensaje(
                        "error",
                        "IDENTIFICACION_NO_ENCONTRADA",
                        "No se encontró la identificación del contribuyente en sesión");

                    return;
                }

                var result = await ServicesContribuyente.ConsultarDeclaracionesContribuyente(
                    new ConsultarDeclaracionContribuyenteDtoParam
                    {
                        Identificacion = identificacion
                    });

                LoadingBorder?.Close();

                if (result?.Data is not null)
                {
                    _declaraciones = result.Data.Declaraciones;
                    StateHasChanged();
                }
                else
                {
                    await MostrarMensaje(
                        "error",
                        result?.Message?.Code ?? "CDC003",
                        result?.Message?.Description ?? "No fue posible consultar las declaraciones registradas");
                }
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

        private void AbrirDetalleDeclaracion(ConsultarDeclaracionContribuyenteDtoResult declaracion)
        {
            FechaGeneracion = DateTime.Now;
            _declaracionSeleccionada = declaracion;
            _mostrarModalDetalle = true;
        }

        private void CerrarDetalleDeclaracion()
        {
            _mostrarModalDetalle = false;
            _declaracionSeleccionada = null;
        }

        private async Task RefrescarConsulta()
        {
            await CargarDeclaraciones();
        }

        private async Task MostrarMensaje(string tipo, string codigo, string descripcion)
        {
            if (Toast is not null)
                await Toast.ShowMessage(tipo, codigo, descripcion);
        }
        private decimal TotalActivo(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return item.ActivoCorriente + item.ActivoNoCorriente;
        }

        private decimal TotalPasivo(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return item.PasivoCorriente + item.PasivoNoCorriente + item.PasivoContingente;
        }

        private decimal Patrimonio(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return TotalActivo(item) - TotalPasivo(item);
        }

        private decimal UtilidadEjercicio(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            var utilidad = item.Ingresos - item.CostosGastos;
            return utilidad > 0 ? utilidad : 0;
        }

        private decimal PerdidaEjercicio(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            var perdida = item.CostosGastos - item.Ingresos;
            return perdida > 0 ? perdida : 0;
        }

        private decimal TotalPatente(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return item.Patente
                   + item.ValorBomberos
                   + item.MultaPatente
                   + item.InteresPatente
                   + item.RecargoPatente
                   + item.CostasPatente
                   + item.TasaAdministrativaPatente
                   - item.DescuentoTerceraEdadPatente;
        }

        private decimal TotalIat(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return item.UnoCincoXMil
                   + item.MultaIat
                   + item.InteresIat
                   + item.RecargoIat
                   + item.CostasIat
                   + item.TasaAdministrativaIat
                   - item.DescuentoTerceraEdadIat;
        }

        private decimal TotalDeclaracion(ConsultarDeclaracionContribuyenteDtoResult item)
        {
            return TotalPatente(item) + TotalIat(item);
        }

        private async Task ImprimirComprobante()
        {
            await JSRuntime.InvokeVoidAsync("imprimirComprobante", "comprobanteConsultaImprimir");
        }
    }
}
