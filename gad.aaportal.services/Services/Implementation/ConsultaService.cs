using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class ConsultaService : IConsultaServices
    {
        private readonly ILogger<ConsultaService> logger;

        public ConsultaService(ILogger<ConsultaService> logger)
        {
            this.logger = logger;
        }

        public async Task<ConsultaAniosResponse> ConsultaAnios(AaportalContext contexto, ConsultaIdentificacionRequest parametros)
        {
            ConsultaAniosResponse result = new ConsultaAniosResponse();
            try
            {
                var query = contexto.Form101.Where(f => f.NumeroIdentificacion == parametros.Identificacion).ToList();
                result.anios = query.Select(f => f.AnioFiscal).ToList();
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<ConsultaRazSocialResponse> ConsultaRazSocial(AaportalContext contexto, ConsultaIdentificacionRequest parametros)
        {
            ConsultaRazSocialResponse result = new ConsultaRazSocialResponse();
            try
            {
                var query = await contexto.Form101.Where(f => f.NumeroIdentificacion == parametros.Identificacion).FirstOrDefaultAsync();
                if (query != null)
                    result.RazSocial = query.RazonSocial;

            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<ConsultaIngresosEgresosResponse> ConsultaIngresosEgresos(AaportalContext contexto, ConsultaIngresosEgresosRequest parametros)
        {
            ConsultaIngresosEgresosResponse result = new ConsultaIngresosEgresosResponse();
            try
            {
                var query = await contexto.Form101.Where(f => f.NumeroIdentificacion == parametros.Identificacion
                                                && f.AnioFiscal == parametros.anio).FirstOrDefaultAsync();
                if (query != null)
                {
                    result.TotalActivoCorriente470 = query.TotalActivoCorriente470.HasValue ? Math.Round(query.TotalActivoCorriente470.Value, 2) : 0;
                    result.TotActivoNoCorriente1077 = query.TotActivoNoCorriente1077.HasValue ? Math.Round(query.TotActivoNoCorriente1077.Value, 2) : 0;
                    result.TotalActivo1080 = query.TotalActivo1080.HasValue ? Math.Round(query.TotalActivo1080.Value, 2) : 0;
                    result.TotPasivosCorrientes1340 = query.TotPasivosCorrientes1340.HasValue ? Math.Round(query.TotPasivosCorrientes1340.Value, 2) : 0;
                    result.TotalPasivosLargoPlazo1590 = query.TotalPasivosLargoPlazo1590.HasValue ? Math.Round(query.TotalPasivosLargoPlazo1590.Value, 2) : 0;
                    result.TotalPasivos1620 = query.TotalPasivos1620.HasValue ? Math.Round(query.TotalPasivos1620.Value, 2) : 0;
                    result.TotalIngresos1930 = query.TotalIngresos1930.HasValue ? Math.Round(query.TotalIngresos1930.Value, 2) : 0;
                    result.TotasCostosGastos3380 = query.TotasCostosGastos3380.HasValue ? Math.Round(query.TotasCostosGastos3380.Value, 2) : 0;
                    result.UtilidadEjercicio3420 = query.UtilidadEjercicio3420.HasValue ? Math.Round(query.UtilidadEjercicio3420.Value, 2) : 0;
                }

            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<CantonesResponse> ConsultaCantones(AaportalContext contexto)
        {
            CantonesResponse result = new CantonesResponse();
            try
            {
                result.Cantones = await contexto.Cantones
                                    .OrderByDescending(c => c.Seleccionado)
                                    .ThenBy(c => c.Provincia)
                                    .Select(c => new Canton
                                    {
                                        Id = c.Id,
                                        Provincia = c.Provincia,
                                        NombreCanton = c.Nombre,
                                        Seleccionado = c.Seleccionado
                                    })
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<ListaTarifas> ConsultaTarifas(AaportalContext contexto)
        {
            ListaTarifas result = new ListaTarifas();
            try
            {
                result.tarifas = await contexto.TarifasImpositivas
                                    .Select(c => new TarifaImpositiva
                                    {
                                        Desde = c.Desde,
                                        Hasta = c.Hasta,
                                        Impuesto = c.Impuesto,
                                        Excedente = c.Excedente
                                    })
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }
    }
}
