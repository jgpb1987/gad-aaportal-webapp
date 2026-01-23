using gad.aaportal.commons.Dto;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Js;
using Microsoft.AspNetCore.Components;

namespace gad.aaportal.webapp.Layout
{
    public partial class MainLayout
    {
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
        private bool collapseNavMenu = true;
        private string? AjusteContenido = "contenido-abierto";
        private string? ShowHide => collapseNavMenu ? "show" : "hide";
        private void ShowMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            if (collapseNavMenu == true)
            {
                AjusteContenido = "contenido-abierto";
            }
            else
            {
                AjusteContenido = "contenido-cerrado";
            }
        }
        protected override async Task OnInitializedAsync()
        {
           var exp= await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Expiration);
           var token= await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Token);
           var ultacceso= await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.UltimoAcceso);
           var nombres= await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Nombres);
            DatosUsuarioResult = new() { 
                Expiration=DateTime.Parse(exp),
                Token=token,
                UltimoAcceso=DateTime.Parse(ultacceso),
                Nombres=nombres
            };
        }
    }
}

