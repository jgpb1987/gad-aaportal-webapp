using gad.aaportal.commons.Dto.Seguridad;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class LoginUserForm : ComponentBase
    {
        [Parameter, EditorRequired] public UsuarioDtoParam Model { get; set; } = default!;

        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }

        [Parameter] public EventCallback OnForgotPassword { get; set; }

        [Parameter] public EventCallback OnChangePassword { get; set; }
    }
}
