using gad.aaportal.commons.Dto.Seguridad;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class UserRegistrationForm : ComponentBase
    {
        [Parameter, EditorRequired] public UserRegistrationDtoParam Model { get; set; } = default!;
        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
        [Parameter] public EventCallback OnBack { get; set; }
        [Parameter] public bool IsValidButton { get; set; }
        [Parameter] public EventCallback<string> OnValidarIdentificacion { get; set; }

        private async Task OnIdentificacionBlur(FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Model.Identificacion) || Model.Identificacion.Length < 13)
                return;

            if (OnValidarIdentificacion.HasDelegate)
                await OnValidarIdentificacion.InvokeAsync(Model.Identificacion);
        }
    }
}
