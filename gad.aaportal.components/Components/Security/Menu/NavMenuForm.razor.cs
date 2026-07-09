using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class NavMenuForm : ComponentBase
    {
        [Parameter] public EventCallback OnNavigate { get; set; }
        [Parameter] public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
        [Inject] private ISpMunicipioConsumers SpMunicipioConsumers { get; set; } = null!;
        public UsuarioDataDtoResult DatosUsuario { get; set; } = null!;
        private List<string> _mediosPago = new();
        protected override async Task OnParametersSetAsync()
        {
            DatosUsuario = DatosUsuarioResult == null ? new UsuarioDataDtoResult() : DatosUsuarioResult;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;
            await CargarMensaje();
        }
        private string? menuAbierto;

        private void ToggleMenu(string menu)
        {
            menuAbierto = menuAbierto == menu ? null : menu;
        }

        private string _mensajeMediosPago = string.Empty;

        private async Task CargarMensaje()
        {
            var result = await SpMunicipioConsumers.ConsultarMensaje();

            if (result.Message.Code != nameof(CodeMessage.OK))
                return;

            _mensajeMediosPago = result.Data.Mensaje ?? string.Empty;

            ProcesarMediosPago();

            await InvokeAsync(StateHasChanged);
        }

        private void ProcesarMediosPago()
        {
            _mediosPago.Clear();

            if (string.IsNullOrWhiteSpace(_mensajeMediosPago))
                return;

            var contenido = _mensajeMediosPago;

            // Elimina el encabezado "Medios de Pago:"
            var posicionDosPuntos = contenido.IndexOf(':');

            if (posicionDosPuntos >= 0)
            {
                contenido = contenido[(posicionDosPuntos + 1)..];
            }

            _mediosPago = contenido
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().TrimEnd('.'))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }
    }
}

