using gad.aaportal.dataaccess;
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
builder.Services.AddScoped<IDinardapService, DinardapService>();
builder.Services.AddScoped<IConsultaServices, ConsultaService>();
// === Fin Services ===

// === CORS ===
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.WithOrigins("https://localhost:7037") // URL Blazor WASM
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// *** Activar CORS ***
app.UseCors("AllowBlazor");

app.UseAuthorization();

app.MapControllers();

app.Run();
