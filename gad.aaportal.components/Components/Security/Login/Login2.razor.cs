using gad.aaportal.commons.Dto;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Login

{
    public partial class Login2
    {
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        private UsuarioDtoParam LoginParam = new();
        private async Task LoginUser()
        {
            LoadingBorder!.Open();
            await Task.Delay(5000);
            LoadingBorder!.Close();
        }
    }
}

