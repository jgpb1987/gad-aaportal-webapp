using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.Services.Interfaces;
using Mapster;
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
                if (parametros.TipoPersona == "PJ")
                {
                    result.anios = await contexto.Form101
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion &&
                                    f.AnioFiscal >= (DateTime.Now.Year - 5) && f.AnioFiscal < (DateTime.Now.Year - 1))
                        .Select(f => f.AnioFiscal)
                        .FirstOrDefaultAsync();
                }
                else if (parametros.TipoPersona == "PN")
                {
                    result.anios = await contexto.Form102
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion &&
                                    f.AnioFiscal>=(DateTime.Now.Year - 5) && f.AnioFiscal < (DateTime.Now.Year - 1))
                        .Select(f => f.AnioFiscal)
                        .FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<ConsultaRazSocialResponse> ConsultaRazSocial(AaportalContext contexto, ConsultaIdentificacionRequest parametros)
        {
            ConsultaRazSocialResponse result = new ConsultaRazSocialResponse();
            try
            {
                if (parametros.TipoPersona == "PJ")
                {
                    result.RazSocial = await contexto.Form101
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion)
                        .Select(f => f.RazonSocial)
                        .FirstOrDefaultAsync();
                }
                else if (parametros.TipoPersona == "PN")
                {
                    result.RazSocial = await contexto.Form102
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion)
                        .Select(f => f.RazonSocial)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    result.RazSocial = string.Empty;
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public async Task<ConsultaIngresosEgresosResponse> ConsultaIngresosEgresos(AaportalContext contexto, ConsultaIngresosEgresosRequest parametros)
        {
            ConsultaIngresosEgresosResponse? result = null;

            try
            {
                if (parametros.TipoPersona == "PJ")
                {
                    var query = await contexto.Form101
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion
                                 && f.AnioFiscal == parametros.anio)
                        .FirstOrDefaultAsync();

                    if (query != null)
                    {
                        result = new ConsultaIngresosEgresosResponse
                        {
                            ActivoCorriente = query.TotalActivoCorriente470.HasValue ? Math.Round(query.TotalActivoCorriente470.Value, 2) : 0,
                            ActivoNoCorriente = query.TotActivoNoCorriente1077.HasValue ? Math.Round(query.TotActivoNoCorriente1077.Value, 2) : 0,
                            TotalActivos = query.TotalActivo1080.HasValue ? Math.Round(query.TotalActivo1080.Value, 2) : 0,
                            PasivoCorriente = query.TotPasivosCorrientes1340.HasValue ? Math.Round(query.TotPasivosCorrientes1340.Value, 2) : 0,
                            PasivoNoCorriente = query.TotalPasivosLargoPlazo1590.HasValue ? Math.Round(query.TotalPasivosLargoPlazo1590.Value, 2) : 0,
                            TotalPasivos = query.TotalPasivos1620.HasValue ? Math.Round(query.TotalPasivos1620.Value, 2) : 0,
                            Ingresos = query.TotalIngresos1930.HasValue ? Math.Round(query.TotalIngresos1930.Value, 2) : 0,
                            CostosGastos = query.TotasCostosGastos3380.HasValue ? Math.Round(query.TotasCostosGastos3380.Value, 2) : 0,
                            UtilidadPerdida = query.UtilidadEjercicio3420.HasValue ? Math.Round(query.UtilidadEjercicio3420.Value, 2) : 0
                        };
                    }
                }
                else if (parametros.TipoPersona == "PN")
                {
                    var query = await contexto.Form102
                        .Where(f => f.NumeroIdentificacion == parametros.Identificacion
                                 && f.AnioFiscal == parametros.anio)
                        .FirstOrDefaultAsync();

                    if (query != null)
                    {
                        result = new ConsultaIngresosEgresosResponse
                        {
                            ActivoCorriente = query.TotActCorriente410.HasValue ? Math.Round(query.TotActCorriente410.Value, 2) : 0,
                            ActivoNoCorriente = query.TotActivoNoCorriente812.HasValue ? Math.Round(query.TotActivoNoCorriente812.Value, 2) : 0,
                            TotalActivos = query.TotalActivo830.HasValue ? Math.Round(query.TotalActivo830.Value, 2) : 0,
                            PasivoCorriente = query.TotPasivoCorriente1030.HasValue ? Math.Round(query.TotPasivoCorriente1030.Value, 2) : 0,
                            PasivoNoCorriente = 0m,
                            TotalPasivos = query.TotalPasivo1310.HasValue ? Math.Round(query.TotalPasivo1310.Value, 2) : 0,
                            Ingresos = query.TotalIngresos1440.HasValue ? Math.Round(query.TotalIngresos1440.Value, 2) : 0,
                            CostosGastos = query.TotalCostosGastos2760.HasValue ? Math.Round(query.TotalCostosGastos2760.Value, 2) : 0,
                            UtilidadPerdida = query.UtilidadNetaEjercicio2800.HasValue ? Math.Round(query.UtilidadNetaEjercicio2800.Value, 2) : 0
                        };
                    }
                }
            }
            catch (Exception)
            {
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

        public async Task<TasasAdministrativas> ConsultaTasasAdministrativas(AaportalContext contexto)
        {
            TasasAdministrativas result = new TasasAdministrativas();
            try
            {
                result.Tasas = await contexto.TasaAdministrativas
                                    .Select(c => new TasaAdministrativa
                                    {
                                        Concepto = c.Concepto,
                                        Valor = c.Valor
                                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<DeclaracionResponse> ConsultaDeclaracion(AaportalContext contexto, ConsultaDeclaracionRequest parametos)
        {
            DeclaracionResponse result = new DeclaracionResponse();
            try
            {
                var declaracion = contexto.DeclaracionPJs.FirstOrDefault(d => d.RUC == parametos.RUC && d.AnioFiscal == parametos.AnioFiscal);
                if (declaracion != null)
                {
                    result.declaracion = new DeclaracionData
                    {
                        ActivoCorriente = declaracion.TotalActivoCorriente470,
                        ActivoNoCorriente = declaracion.TotActivoNoCorriente1077,
                        AnioFiscal = declaracion.AnioFiscal,
                        CostosGastos = declaracion.TotasCostosGastos3380,
                        Ingresos = declaracion.TotalIngresos1930,
                        PasivoCorriente = declaracion.TotPasivosCorrientes1340,
                        PasivoContingente = declaracion.TotalPasivosContingente,
                        PasivoLargoPlazo = declaracion.TotalPasivosLargoPlazo1590,
                        RUC = declaracion.RUC,
                        ValorPatente = declaracion.ValorPatente,
                    };
                }
                result.distribuciones = contexto.DistribucionPagos.Where(d => d.RUC == parametos.RUC && d.AnioFiscal == parametos.AnioFiscal).ToList().Adapt<List<DistribucionPagoDto>>();
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
