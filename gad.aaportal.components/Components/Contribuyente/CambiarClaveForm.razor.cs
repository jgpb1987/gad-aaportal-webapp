using gad.aaportal.commons.Dto.Log;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Consumers.Interface;
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
    public partial class CambiarClaveForm : ComponentBase
    {
        private CambiarClaveDtoParam Model { get; set; } = new();

        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ISeguridadConsumers ServicesUsuario { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISecurityAlgorithmConsumers SecurityAlgorithm { get; set; } = null!;
        [Inject] private IJSRuntime Js { get; set; } = null!;
        [Inject] private NavigationManager UriHelper { get; set; } = null!;

        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var usuario = await JSSessionStorageServices
                .GetItemAsync(Configuraciones.AppConfig.Identificacion);

            Model.User = usuario ?? string.Empty;
        }

        private async Task OnSubmit()
        {
            try
            {
                LoadingBorder?.Open();
                var publicKeyServer = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.SesionStoragePublicKeyServer);

                if (string.IsNullOrWhiteSpace(Model.User))
                {
                    LoadingBorder?.Close();

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage(
                            "error",
                            "USUARIO_NO_ENCONTRADO",
                            "No se encontró el usuario en sesión.");
                    }

                    return;
                }

                if (Model.PasswordNueva != Model.PasswordNuevaConfirmacion)
                {
                    LoadingBorder?.Close();

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage(
                            "error",
                            "CLAVE_NO_COINCIDE",
                            "La confirmación no coincide con la nueva contraseña.");
                    }

                    return;
                }

                var userRsaPA = await SecurityAlgorithm.EncryptRsa(Js, Model.PasswordActual, publicKeyServer!);
                var userRsaNewPA = await SecurityAlgorithm.EncryptRsa(Js, Model.PasswordNueva, publicKeyServer!);
                var userRsaNewCPA = await SecurityAlgorithm.EncryptRsa(Js, Model.PasswordNuevaConfirmacion, publicKeyServer!);
                Model.PasswordActual = userRsaPA;
                Model.PasswordNueva = userRsaNewPA;
                Model.PasswordNuevaConfirmacion = userRsaNewCPA;
                var result = await ServicesUsuario.CambiarClave(Model);

                if (result?.Data is not null && result.Data.CambioCorrecto)
                {
                    LimpiarFormulario();

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage(
                            "success",
                            result.Message.Code,
                            result.Message.Description);
                    }
                    StateHasChanged();
                    LoadingBorder?.Close();
                    UriHelper.NavigateTo("/");
                }
                else
                {
                    var code = result?.Message?.Code ?? "CAMBIO_CLAVE_ERROR";
                    var description = result?.Message?.Description ?? "No fue posible cambiar la contraseña.";

                    if (Toast is not null)
                    {
                        await Toast.ShowMessage("error", code, description);
                    }
                    StateHasChanged();
                    LoadingBorder?.Close();
                }
            }
            catch (Exception)
            {
                LoadingBorder?.Close();

                if (Toast is not null)
                {
                    await Toast.ShowMessage(
                        "error",
                        "SERVER_ERROR",
                        "Existe un error no administrado, por favor informe a Tecnología.");
                }
            }
        }

        private void LimpiarFormulario()
        {
            Model.PasswordActual = string.Empty;
            Model.PasswordNueva = string.Empty;
            Model.PasswordNuevaConfirmacion = string.Empty;
        }
    }
}
