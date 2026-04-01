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
        private string SearchTerm { get; set; } = string.Empty;
        protected override async Task OnParametersSetAsync()
        {
            DatosUsuario = DatosUsuarioResult == null ? new UsuarioDataDtoResult() : DatosUsuarioResult;
        }
        private void OnSearchInput(ChangeEventArgs e)
        {
            SearchTerm = e.Value!.ToString()!;
            SearchMenu();
        }
        private void OnButtonSearchInput()
        {
            SearchMenu();
        }
        private void SearchMenu()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                //expandir = false;
                //FilteredMenu = ListaMenu;
            }
            else
            {
                //expandir = true;
                var searchTermLower = SearchTerm.ToLower();
                var uniqueTitles = new HashSet<string>();
            }
            StateHasChanged();
        }

        private async Task NotifyNavigate()
        {
            if (OnNavigate.HasDelegate)
                await OnNavigate.InvokeAsync();
        }
    }
}

