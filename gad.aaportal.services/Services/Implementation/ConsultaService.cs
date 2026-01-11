using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Dinardap;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    result.TotalActivoCorriente470 = query.TotalActivoCorriente470;
                    result.TotActivoNoCorriente1077 = query.TotActivoNoCorriente1077;
                    result.TotalActivo1080 = query.TotalActivo1080;
                    result.TotPasivosCorrientes1340 = query.TotPasivosCorrientes1340;
                    result.TotalPasivosLargoPlazo1590 = query.TotalPasivosLargoPlazo1590;
                    result.TotalPasivos1620 = query.TotalPasivos1620;
                    result.TotalIngresos1930 = query.TotalIngresos1930;
                    result.TotasCostosGastos3380 = query.TotasCostosGastos3380;
                    result.UtilidadEjercicio3420 = query.UtilidadEjercicio3420;
                }

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
