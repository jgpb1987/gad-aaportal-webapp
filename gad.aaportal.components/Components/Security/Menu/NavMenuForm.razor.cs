using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class NavMenuForm : ComponentBase
    {
        [Parameter] public EventCallback OnNavigate { get; set; }
        [Parameter] public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
        public UsuarioDataDtoResult DatosUsuario { get; set; } = null!;
        protected override async Task OnParametersSetAsync()
        {
            DatosUsuario = DatosUsuarioResult == null ? new UsuarioDataDtoResult() : DatosUsuarioResult;
        }

        private string? menuAbierto;

        private void ToggleMenu(string menu)
        {
            menuAbierto = menuAbierto == menu ? null : menu;
        }
    }
}

