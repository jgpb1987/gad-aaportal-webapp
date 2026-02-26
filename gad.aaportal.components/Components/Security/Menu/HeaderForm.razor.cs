using gad.aaportal.commons.Dto.Seguridad;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Menu
{
    public partial class HeaderForm
    {
        [Parameter] public EventCallback OnButtonClick { get; set; }
        [Parameter] public UsuarioDataDtoResult DatosUsuarioResult { get; set; } = null!;
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
        private void OnClickInfo()
        {
            if (Visible.Equals("block"))
            {
                Visible = "none";
            }
            else
            {
                band = 1;
                Visible = "block";
            }
        }
    }
}

