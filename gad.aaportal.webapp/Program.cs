using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Consumers.Implementation;
using gad.aaportal.consumers.Consumers.Interface;
using gad.aaportal.consumers.Js;
using gad.aaportal.webapp;
using gad.aaportal.webapp.Js;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var serverConfig = new ServerApisConfig();
builder.Configuration.Bind("ServerApisConfig", serverConfig);
builder.Services.AddSingleton(serverConfig);
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri(serverConfig.ApiServer1!.ToString().Trim())
    };
    return httpClient;
});
//Inicio JS
builder.Services.AddScoped<ISessionStorageServices, WebSessionStorageService>();
//Fin JS
//Inicio Consumers
builder.Services.AddScoped<ISeguridadConsumers, SeguridadConsumers>();
builder.Services.AddScoped<ISecurityAlgorithmConsumers, SecurityAlgorithmConsumers>();
//Fin Consumers
//Inicio config
builder.Services.AddSingleton(provider =>
{
    var configuracion = provider.GetRequiredService<IConfiguration>();
    var configuraciones = new ConfiguracionesApp();
    configuracion.GetSection("AppConfig").Bind(configuraciones.AppConfig);
    configuracion.GetSection("ServerApisConfig").Bind(configuraciones.ServerApisConfig);
    configuracion.GetSection("EndPointsConfig").Bind(configuraciones.EndPointsConfig);
    return configuraciones;
});

// 📌 Fijar cultura global (punto decimal, 0.00)
var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
//Fin config

await builder.Build().RunAsync();
