using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.generic.components.Components.Several;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace gad.aaportal.components.Components.Security.Auth
{
    public partial class LoginAuthForm : ComponentBase
    {
        private enum LoginView { Login, ForgotPassword, UserRegistration }
        private LoginView _view = LoginView.Login;

        private ForgotPasswordDtoParam _forgotParam = new();
        private UserRegistrationDtoParam _userRegistrationParam = new();
        [Inject] private NavigationManager UriHelper { get; set; } = null!;
        [Inject] private ISeguridadConsumers SeguridadConsumers { get; set; } = null!;
        [Inject] private IServicesExternsConsumers ServicesExterns { get; set; } = null!;
        [Inject] private ISessionStorageServices JSSessionStorageServices { get; set; } = null!;
        [Inject] private ConfiguracionesApp Configuraciones { get; set; } = null!;
        [Inject] private ISecurityAlgorithmConsumers SecurityAlgorithm { get; set; } = null!;
        [Inject] private IJSRuntime Js { get; set; } = null!;
        [Inject] private ISpMunicipioConsumers SpMunicipioConsumers { get; set; } = null!;
        public ToastsServices? Toast { get; set; }
        private LoadingBorderModalServices? LoadingBorder { get; set; }
        private UsuarioDtoParam LoginParam = new();
        private void ShowLogin() => _view = LoginView.Login;
        public bool IsValidButton = true;
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
        private void ShowForgotPassword()
        {
            _forgotParam = new ForgotPasswordDtoParam();
            _view = LoginView.ForgotPassword;
        }

        private void ShowUserRegistration()
        {
            _userRegistrationParam = new UserRegistrationDtoParam();
            IsValidButton = true;
            _view = LoginView.UserRegistration;
        }
        private async Task SubmitForgotPassword()
        {
            try
            {
                LoadingBorder!.Open();
                var dataDispositivo = await JSSessionStorageServices.GetInfoDispositivoUsuario();
                var forgotPasswordRequest = new ForgotPasswordDtoParam()
                {
                    Browser = dataDispositivo.Browser == null ? string.Empty : dataDispositivo.Browser,
                    Geolocation = dataDispositivo.Geolocation == null ? string.Empty : dataDispositivo.Geolocation,
                    Ip = dataDispositivo.Ip == null ? string.Empty : dataDispositivo.Ip,
                    Language = dataDispositivo.Language == null ? string.Empty : dataDispositivo.Language,
                    OperatingSystem = dataDispositivo.OperatingSystem == null ? string.Empty : dataDispositivo.OperatingSystem,
                    Plugins = dataDispositivo.Plugins == null ? string.Empty : dataDispositivo.Plugins,
                    TimeZone = dataDispositivo.TimeZone == null ? string.Empty : dataDispositivo.TimeZone,
                    UserAgent = dataDispositivo.UserAgent == null ? string.Empty : dataDispositivo.UserAgent,
                    User = _forgotParam.User,
                    Email = _forgotParam.Email
                };
                var urResponse = await SeguridadConsumers.ForgotPassword(forgotPasswordRequest);
                if (urResponse != null)
                {
                    if (urResponse.Message.Code.Equals("OK"))
                    {
                        LoadingBorder!.Close();
                        _view = LoginView.Login;
                        Toast!.ShowMessage("success", urResponse.Message.Code, urResponse.Message.Description);
                        ShowLogin();
                    }
                    else
                    {
                        LoadingBorder!.Close();
                        await Toast!.ShowMessage("error", urResponse.Message.Code, urResponse.Message.Description);
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
        private async Task SubmitUserRegistration()
        {
            try
            {
                LoadingBorder!.Open();
                var dataDispositivo = await JSSessionStorageServices.GetInfoDispositivoUsuario();
                var userRegistrationRequest = new UserRegistrationDtoParam()
                {
                    Browser = dataDispositivo.Browser == null ? string.Empty : dataDispositivo.Browser,
                    Geolocation = dataDispositivo.Geolocation == null ? string.Empty : dataDispositivo.Geolocation,
                    Ip = dataDispositivo.Ip == null ? string.Empty : dataDispositivo.Ip,
                    Language = dataDispositivo.Language == null ? string.Empty : dataDispositivo.Language,
                    OperatingSystem = dataDispositivo.OperatingSystem == null ? string.Empty : dataDispositivo.OperatingSystem,
                    Plugins = dataDispositivo.Plugins == null ? string.Empty : dataDispositivo.Plugins,
                    TimeZone = dataDispositivo.TimeZone == null ? string.Empty : dataDispositivo.TimeZone,
                    UserAgent = dataDispositivo.UserAgent == null ? string.Empty : dataDispositivo.UserAgent,
                    User = _userRegistrationParam.User,
                    Email = _userRegistrationParam.Email,
                    Nombres = _userRegistrationParam.Nombres,
                    Identificacion = _userRegistrationParam.Identificacion,
                    RazonSocial = _userRegistrationParam.RazonSocial,
                    EstadoContribuyenteRuc = _userRegistrationParam.EstadoContribuyenteRuc,
                    ActividadEconomicaPrincipal = _userRegistrationParam.ActividadEconomicaPrincipal,
                    TipoContribuyente = _userRegistrationParam.TipoContribuyente,
                    Regimen = _userRegistrationParam.Regimen,
                    ObligadoLlevarContabilidad = _userRegistrationParam.ObligadoLlevarContabilidad,
                    AgenteRetencion = _userRegistrationParam.AgenteRetencion,
                    ContribuyenteEspecial = _userRegistrationParam.ContribuyenteEspecial,
                    FechaInicioActividades = _userRegistrationParam.FechaInicioActividades,
                    FechaReinicioActividades = _userRegistrationParam.FechaReinicioActividades,
                    FechaActualizacion = _userRegistrationParam.FechaActualizacion,
                    TransaccionesInexistente = _userRegistrationParam.TransaccionesInexistente,
                    ContribuyenteFantasma = _userRegistrationParam.ContribuyenteFantasma,
                    Establecimientos = _userRegistrationParam.Establecimientos,
                    AceptaPoliticasTratamientoDatos = _userRegistrationParam.AceptaPoliticasTratamientoDatos,
                    PoliticasTratamientoDatos = _userRegistrationParam.PoliticasTratamientoDatos
                };
                var urResponse = await SeguridadConsumers.UserRegistration(userRegistrationRequest);
                if (urResponse != null)
                {
                    if (urResponse.Message.Code.Equals("OK"))
                    {
                        LoadingBorder!.Close();
                        _view = LoginView.Login;
                        Toast!.ShowMessage("success", urResponse.Message.Code, urResponse.Message.Description);
                        ShowLogin();
                    }
                    else
                    {
                        LoadingBorder!.Close();
                        await Toast!.ShowMessage("error", urResponse.Message.Code, urResponse.Message.Description);
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
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Expiration, loginResponse.Data.Expiration.ToString());
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Token, loginResponse.Data.Token);
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.UltimoAcceso, loginResponse.Data.UltimoAcceso.ToString());
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Nombres, loginResponse.Data.Nombres);
                            await JSSessionStorageServices.SetItemAsync(Configuraciones.AppConfig.Identificacion, loginResponse.Data.Identificacion);
                            LoadingBorder!.Close();
                            //await ConsultaDinardap();
                            UriHelper.NavigateTo("/index");
                            await Toast!.ShowMessage("success", loginResponse.Message.Code, loginResponse.Message.Description);
                        }
                        else
                        {
                            LoadingBorder!.Close();
                            await Toast!.ShowMessage("error", loginResponse.Message.Code, loginResponse.Message.Description);
                        }
                    }
                    else if (loginResponse.Message == null)
                    {
                        LoadingBorder!.Close();
                        await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
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
            catch (Exception ex)
            {
                LoadingBorder!.Close();
                await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
        private async Task ValidarIdentificacion(string identificacion)
        {
            EncerarValores();
            try
            {
                LoadingBorder!.Open();
                var result = await ServicesExterns.SearchInfoRucSri(identificacion);
                if (result != null)
                {
                    var resultFirst = result.FirstOrDefault(p => p.EstadoContribuyenteRuc.Equals("ACTIVO"));
                    if (resultFirst != null)
                    {
                        var resultEstablecimientos = await ServicesExterns.SearchInfoEstablecimientoSri(identificacion);
                        if (resultEstablecimientos != null)
                        {
                            var resultEstablecimientosFirst = resultEstablecimientos.FirstOrDefault(p => p.Estado.Equals("ABIERTO"));
                            if (resultEstablecimientosFirst != null)
                            {
                                _userRegistrationParam.Identificacion = identificacion;
                                _userRegistrationParam.User = identificacion;
                                _userRegistrationParam.Nombres = resultFirst!.RazonSocial;
                                _userRegistrationParam.RazonSocial = resultFirst!.RazonSocial;
                                _userRegistrationParam.EstadoContribuyenteRuc = resultFirst!.EstadoContribuyenteRuc;
                                _userRegistrationParam.ActividadEconomicaPrincipal = resultFirst!.ActividadEconomicaPrincipal;
                                _userRegistrationParam.TipoContribuyente = resultFirst!.TipoContribuyente;
                                _userRegistrationParam.Regimen = resultFirst!.Regimen;
                                _userRegistrationParam.ObligadoLlevarContabilidad = resultFirst!.ObligadoLlevarContabilidad;
                                _userRegistrationParam.AgenteRetencion = resultFirst!.AgenteRetencion;
                                _userRegistrationParam.ContribuyenteEspecial = resultFirst!.ContribuyenteEspecial;
                                _userRegistrationParam.FechaInicioActividades = !string.IsNullOrEmpty(resultFirst!.InformacionFechasContribuyente.FechaInicioActividades) ? DateTime.Parse(resultFirst!.InformacionFechasContribuyente.FechaInicioActividades) : DateTime.Parse("01/01/1900");
                                _userRegistrationParam.FechaReinicioActividades = !string.IsNullOrEmpty(resultFirst!.InformacionFechasContribuyente.FechaReinicioActividades) ? DateTime.Parse(resultFirst!.InformacionFechasContribuyente.FechaReinicioActividades) : DateTime.Parse("01/01/1900");
                                _userRegistrationParam.FechaActualizacion = !string.IsNullOrEmpty(resultFirst!.InformacionFechasContribuyente.FechaActualizacion) ? DateTime.Parse(resultFirst!.InformacionFechasContribuyente.FechaActualizacion) : DateTime.Parse("01/01/1900");
                                _userRegistrationParam.TransaccionesInexistente = resultFirst!.TransaccionesInexistente;
                                _userRegistrationParam.ContribuyenteFantasma = resultFirst!.ContribuyenteFantasma;
                                _userRegistrationParam.Establecimientos = new();
                                foreach (var establecimiento in resultEstablecimientos)
                                {
                                    var direccionParts = establecimiento.DireccionCompleta.Split('/');
                                    _userRegistrationParam.Establecimientos.Add(new ContribuyenteEstablecimientoDtoParam()
                                    {
                                        NombreFantasiaComercial = string.IsNullOrEmpty(establecimiento.NombreFantasiaComercial) ? string.Empty : establecimiento.NombreFantasiaComercial,
                                        DireccionCompleta = establecimiento.DireccionCompleta,
                                        Estado = establecimiento.Estado,
                                        NumeroEstablecimiento = establecimiento.NumeroEstablecimiento,
                                        Matriz = establecimiento.Matriz,
                                        Calles = direccionParts[3].ToString().Trim(),
                                        Canton = direccionParts[1].ToString().Trim(),
                                        Parroquia = direccionParts[2].ToString().Trim(),
                                        Provincia = direccionParts[0].ToString().Trim()
                                    });
                                }
                                IsValidButton = false;
                                LoadingBorder!.Close();
                            }
                            else
                            {
                                IsValidButton = false;
                                LoadingBorder!.Close();
                                await Toast!.ShowMessage("warning", "SRI004", "El Ruc no posee establecimientos activos");
                            }
                        }
                        else
                        {
                            IsValidButton = false;
                            LoadingBorder!.Close();
                            await Toast!.ShowMessage("warning", "SRI003", "El Ruc no posee establecimientos");
                        }
                    }
                    else
                    {
                        IsValidButton = true;
                        LoadingBorder!.Close();
                        await Toast!.ShowMessage("warning", "SRI001", "El Ruc no se encuentra activo en el SRI");
                    }
                }
                else
                {
                    IsValidButton = true;
                    LoadingBorder!.Close();
                    await Toast!.ShowMessage("warning", "SRI002", "El Ruc no existe en el SRI");
                }

            }
            catch (Exception ex)
            {
                IsValidButton = true;
                LoadingBorder!.Close();
                await Toast!.ShowMessage("error", "SERVER_ERROR", "Existe un error no administrado, por favor informe a Tecnología");
            }
        }
        private void EncerarValores()
        {
            _userRegistrationParam.Identificacion = string.Empty;
            _userRegistrationParam.User = string.Empty;
            _userRegistrationParam.Nombres = string.Empty;
            _userRegistrationParam.RazonSocial = string.Empty;
            _userRegistrationParam.EstadoContribuyenteRuc = string.Empty;
            _userRegistrationParam.ActividadEconomicaPrincipal = string.Empty;
            _userRegistrationParam.TipoContribuyente = string.Empty;
            _userRegistrationParam.Regimen = string.Empty;
            _userRegistrationParam.ObligadoLlevarContabilidad = string.Empty;
            _userRegistrationParam.AgenteRetencion = string.Empty;
            _userRegistrationParam.ContribuyenteEspecial = string.Empty;
            _userRegistrationParam.FechaInicioActividades = DateTime.Parse("01/01/1900");
            _userRegistrationParam.FechaReinicioActividades = DateTime.Parse("01/01/1900");
            _userRegistrationParam.FechaActualizacion = DateTime.Parse("01/01/1900");
            _userRegistrationParam.TransaccionesInexistente = string.Empty;
            _userRegistrationParam.Email = string.Empty;
            _userRegistrationParam.ContribuyenteFantasma = string.Empty;
            IsValidButton = true;
        }
        private async Task ConsultaDinardap()
        {
            using var http = new HttpClient { BaseAddress = new Uri("https://localhost:7003/") };
            var parametros = new { Identificacion = "asd", Paquete = "6281", Usuario = "ccabrera" };
            var resp = await http.PostAsJsonAsync("api/Dinardap/PaqueteIndividual", parametros);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadFromJsonAsync<ConsumoDinardapResult>();
        }
    }
}
