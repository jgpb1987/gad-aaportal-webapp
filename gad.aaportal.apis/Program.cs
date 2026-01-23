using gad.aaportal.dataaccess;
using gad.aaportal.services.Config;
using gad.aaportal.services.Services.Implementation;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var PolicyCors = "_policyCors";
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// === Inicio DbContext ===
builder.Services.AddDbContext<AaportalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
// === Fin DbContext ===

// === Inicio Services ===
builder.Services.AddScoped<ISeguridadServices, SeguridadServices>();
builder.Services.AddScoped<ISecurityAlgorithmServices, SecurityAlgorithmServices>();
builder.Services.AddScoped<IDinardapService, DinardapService>();
builder.Services.AddScoped<IConsultaServices, ConsultaService>();
builder.Services.AddScoped<IDeclaracionServices, DeclaracionServices>();
//Fin Services
//Inicio Politicas de Cors
builder.Services.AddCors(
  options =>
  {
      var origin = new List<string>();
      builder.Configuration.Bind("PolicyCoreConfig", origin);
      options.AddPolicy(name: PolicyCors,
      builder =>
      {
          builder.WithOrigins(origin.Distinct().ToArray()).AllowAnyHeader().AllowAnyMethod();
      });
  });
//Fin Políticas de Cors
//Inicio archivo configuración
builder.Services.Configure<ServicesConfig>(builder.Configuration.GetSection("ServicesConfig"));
//Fin archivo configuración

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//Inicio Configuración Politicas Cors
app.UseCors(PolicyCors);
//Fin Configuracion Políticas Cors
app.UseAuthorization();

app.MapControllers();

app.Run();
