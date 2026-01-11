using gad.aaportal.consumers.Js;
using gad.aaportal.webapp;
using gad.aaportal.webapp.Js;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Inicio JS
builder.Services.AddScoped<ISessionStorageService, WebSessionStorageService>();
//Fin JS
await builder.Build().RunAsync();

