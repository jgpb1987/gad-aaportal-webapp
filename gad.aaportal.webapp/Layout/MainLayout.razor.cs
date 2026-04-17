using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Js;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace gad.aaportal.webapp.Layout
{
    public partial class MainLayout : IDisposable
    {
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private IJSRuntime JS { get; set; } = null!;
        [Inject] private NavigationManager Nav { get; set; } = null!;
        public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
        private bool collapseNavMenu = true;
        public bool IsMobile { get; set; }
        private DotNetObjectReference<MainLayout>? _ref;

        protected override async Task OnInitializedAsync()
        {
            var exp = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Expiration);
            var token = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Token);
            var ultacceso = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.UltimoAcceso);
            var nombres = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.Nombres);
            DatosUsuarioResult = new()
            {
                Expiration = DateTime.Parse(exp),
                Token = token,
                UltimoAcceso = DateTime.Parse(ultacceso),
                Nombres = nombres
            };
            Nav.LocationChanged += OnLocationChanged;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;

            _ref = DotNetObjectReference.Create(this);
            IsMobile = await JS.InvokeAsync<bool>("layoutInterop.isMobile", 768);
            collapseNavMenu = !IsMobile;
            await JS.InvokeVoidAsync("layoutInterop.listenResize", _ref, 768);
            StateHasChanged();
        }

        private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            if (IsMobile && collapseNavMenu)
            {
                collapseNavMenu = false;
                await JS.InvokeVoidAsync("layoutInterop.unlockBodyScroll");
                await InvokeAsync(StateHasChanged);
            }
        }

        private async void ShowMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            if (IsMobile)
            {
                if (collapseNavMenu) await JS.InvokeVoidAsync("layoutInterop.lockBodyScroll");
                else await JS.InvokeVoidAsync("layoutInterop.unlockBodyScroll");
            }

            await InvokeAsync(StateHasChanged);
        }

        private async void CloseMenu()
        {
            collapseNavMenu = false;
            if (IsMobile) await JS.InvokeVoidAsync("layoutInterop.unlockBodyScroll");
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnMenuNavigate()
        {
            if (IsMobile)
            {
                CloseMenu();
            }

            await Task.CompletedTask;
        }

        [JSInvokable]
        public async Task OnResizeChanged(bool nowMobile)
        {
            if (IsMobile == nowMobile) return;

            IsMobile = nowMobile;
            collapseNavMenu = !IsMobile;

            if (!IsMobile)
                await JS.InvokeVoidAsync("layoutInterop.unlockBodyScroll");

            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            Nav.LocationChanged -= OnLocationChanged;
            _ref?.Dispose();
        }
    }
}

