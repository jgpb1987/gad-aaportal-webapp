using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class HeaderForm
    {
        [Parameter] public EventCallback OnButtonClick { get; set; }
        [Parameter] public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        public UsuarioDataDtoResult DatosUsuario { get; set; } = null!;
        private string Visible = "none";
        private int band = 0;
        private async Task OnClick()
        {
            await OnButtonClick.InvokeAsync();
        }
        protected override async Task OnParametersSetAsync()
        {
            DatosUsuario = DatosUsuarioResult == null ? new UsuarioDataDtoResult() : DatosUsuarioResult;
        }
        private async Task CerrarSesion()
        {
            LoadingBorder!.Open();
            await JSSessionStorageServices.RemoveItemAsync(Configuraciones.AppConfig.Expiration);
            await JSSessionStorageServices.RemoveItemAsync(Configuraciones.AppConfig.Token);
            await JSSessionStorageServices.RemoveItemAsync(Configuraciones.AppConfig.UltimoAcceso);
            await JSSessionStorageServices.RemoveItemAsync(Configuraciones.AppConfig.Nombres);
            await Task.Delay(2000);
            LoadingBorder!.Close();
            UriHelper.NavigateTo("/");
        }

    }
}

