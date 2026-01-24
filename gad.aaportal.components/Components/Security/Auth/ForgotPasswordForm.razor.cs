using gad.aaportal.commons.Dto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class ForgotPasswordForm : ComponentBase
    {
        [Parameter, EditorRequired] public ForgotPasswordDtoParam Model { get; set; } = default!;
        [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
        [Parameter] public EventCallback OnBack { get; set; }
    }
}
