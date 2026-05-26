using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Consumers.Implementation;
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
    public partial class ResumenContribuyenteForm : ComponentBase
    {
        private ContribuyenteResumenDataDtoResult _contribuyenteResumen = new();
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IContribuyenteConsumers ServicesContribuyente { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _contribuyenteResumen.Data = new();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await CargarResumenContribuyente();
        }

        private async Task CargarResumenContribuyente()
        {
            try
            {
                LoadingBorder?.Open();

                var identificacion = await JSSessionStorageServices
                    .GetItemAsync(Configuraciones.AppConfig.Identificacion);

                if (string.IsNullOrWhiteSpace(identificacion))
                {
                    LoadingBorder?.Close();

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage(
                            "error",
                            "IDENTIFICACION_NO_ENCONTRADA",
                            "No se encontró la identificación del contribuyente en sesión.");
                    }

                    return;
                }

                var result = await ServicesContribuyente.ResumenContribuyente(
                    new ContribuyenteResumenDtoParam
                    {
                        Identificacion = identificacion
                    });

                if (result?.Data is not null)
                {
                    _contribuyenteResumen = result;

                    LoadingBorder?.Close();

                    //if (Toast is not null && result.Message is not null)
                    //{
                    //    await Toast.ShowMessage(
                    //        "success",
                    //        result.Message.Code,
                    //        result.Message.Description);
                    //}
                }
                else
                {
                    LoadingBorder?.Close();

                    var code = result?.Message?.Code ?? "SIN_DATOS";
                    var description = result?.Message?.Description ?? "No se encontró información del contribuyente.";

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage("error", code, description);
                    }
                }

                StateHasChanged();
            }
            catch
            {
                LoadingBorder?.Close();

                if (Toast is not null)
                {
                    await Toast.ShowMessage(
                        "error",
                        "SERVER_ERROR",
                        "Existe un error no administrado, por favor informe a Tecnología");
                }
            }
        }
    }
}
