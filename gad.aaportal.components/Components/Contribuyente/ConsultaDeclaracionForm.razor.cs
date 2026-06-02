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
    public partial class ConsultaDeclaracionForm : ComponentBase
    {
        private List<ConsultarDeclaracionContribuyenteDtoResult> _declaraciones = new();
        private ConsultarDeclaracionContribuyenteDtoResult? _declaracionSeleccionada;

        private bool _mostrarModalDetalle;

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesContribuyente { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;

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
    }
}
