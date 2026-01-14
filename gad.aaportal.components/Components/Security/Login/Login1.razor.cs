using gad.aaportal.commons.Dto;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.models.Entity.Seguridad;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Login
{
    public partial class Login1 : ComponentBase
    {
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        [Inject] private ISeguridadConsumers SeguridadConsumers { get; set; } = null!;
        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        private UsuarioDtoParam LoginParam = new();
        private async Task LoginUser()
        {
            LoadingBorder!.Open();
            var publicrsa=await SeguridadConsumers.GetPublicKey();
            await Task.Delay(5000);
            LoadingBorder!.Close();
            //UriHelper.NavigateTo("/index");
        }
    }
}

