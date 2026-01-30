using gad.aaportal.commons.Dto;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class LoginForm : ComponentBase
    {
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        [Inject] private ISeguridadConsumers SeguridadConsumers { get; set; } = null!;
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISecurityAlgorithmConsumers SecurityAlgorithm { get; set; } = null!;
        [Inject] private IJSRuntime Js { get; set; } = null!;
        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        private UsuarioDtoParam LoginParam = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var publicKeyServer = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.SesionStoragePublicKeyServer);
                if (publicKeyServer == null)
                {
                    var publicServerRsa = await SeguridadConsumers.GetPublicKey();
                    await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.SesionStoragePublicKeyServer, publicServerRsa.Data.PublicKey);
                }
            }
            catch (Exception ex)
            {
                await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }

        }
        private async Task LoginUser()
        {
            try
            {
                LoadingBorder!.Open();
                var publicKeyServer = await JSSessionStorageServices.GetItemAsync(Configuraciones.AppConfig.SesionStoragePublicKeyServer);
                var userRsa = await SecurityAlgorithm.EncryptRsa(Js, LoginParam.User, publicKeyServer!);
                var pwdRsa = await SecurityAlgorithm.EncryptRsa(Js, LoginParam.Password, publicKeyServer!);
                var dataDispositivo = await JSSessionStorageServices.GetInfoDispositivoUsuario();
                var loginRequest = new UsuarioDtoParam()
                {
                    User = userRsa,
                    Password = pwdRsa,
                    Browser = dataDispositivo.Browser == null ? string.Empty : dataDispositivo.Browser,
                    Geolocation = dataDispositivo.Geolocation == null ? string.Empty : dataDispositivo.Geolocation,
                    Ip = dataDispositivo.Ip == null ? string.Empty : dataDispositivo.Ip,
                    Language = dataDispositivo.Language == null ? string.Empty : dataDispositivo.Language,
                    OperatingSystem = dataDispositivo.OperatingSystem == null ? string.Empty : dataDispositivo.OperatingSystem,
                    Plugins = dataDispositivo.Plugins == null ? string.Empty : dataDispositivo.Plugins,
                    TimeZone = dataDispositivo.TimeZone == null ? string.Empty : dataDispositivo.TimeZone,
                    UserAgent = dataDispositivo.UserAgent == null ? string.Empty : dataDispositivo.UserAgent
                };
                var loginResponse = await SeguridadConsumers.Login(loginRequest);
                if (loginResponse != null)
                {
                    if (loginResponse.Data != null)
                    {
                        if (loginResponse.Message.Code.Equals("OK"))
                        {
                            LoadingBorder!.Close();
                            await Toast!.ShowMessage("success", loginResponse.Message.Code, loginResponse.Message.Description);
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Expiration, loginResponse.Data.Expiration.ToString());
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Token, loginResponse.Data.Token);
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.UltimoAcceso, loginResponse.Data.UltimoAcceso.ToString());
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Nombres, loginResponse.Data.Nombres);
                            UriHelper.NavigateTo("/index");

                        }
                        else
                        {
                            LoadingBorder!.Close();
                            await Toast!.ShowMessage("error", loginResponse.Message.Code, loginResponse.Message.Description);
                        }
                    }
                    else
                    {
                        LoadingBorder!.Close();
                        await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                    }
                }
                else
                {
                    LoadingBorder!.Close();
                    await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
                }
            }
            catch (Exception ex)
            {
                LoadingBorder!.Close();
                await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
    }
}

