using gad.aaportal.dataaccess;
using gad.aaportal.services.Config;
using gad.aaportal.services.Services.Implementation;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inicio DbContext
builder.Services.AddDbContext<AaportalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
//Fin DbContext

//Inicio Services
builder.Services.AddScoped<ISeguridadServices, SeguridadServices>();
builder.Services.AddScoped<ISecurityAlgorithmServices, SecurityAlgorithmServices>();
//Fin Services

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

app.UseAuthorization();

app.MapControllers();

app.Run();

