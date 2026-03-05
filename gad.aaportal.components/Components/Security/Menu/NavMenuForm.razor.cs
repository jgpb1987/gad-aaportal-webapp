using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class NavMenuForm
    {
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        private string SearchTerm { get; set; } = string.Empty;
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

