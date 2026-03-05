using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Aplicacion;
using gad.aaportal.services.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class DeclaracionServices : IDeclaracionServices
    {
        private readonly ILogger<DeclaracionServices> logger;

        public DeclaracionServices(ILogger<DeclaracionServices> logger)
        {
            this.logger = logger;
        }

        public async Task<SaveDeclaracionPJResult> GrabarDeclaracionPJ(AaportalContext contexto, DeclaracionRequest parametros)
        {
            SaveDeclaracionPJResult result = new SaveDeclaracionPJResult();
            try
            {
                var declaracion = new DeclaracionPJ
                {
                    AnioFiscal = parametros.declaracion.AnioFiscal,
                    ValorUnoPorMil = parametros.declaracion.ValorUnoPorMil,
                    ValorPatente = parametros.declaracion.ValorPatente,
                    UtilidadEjercicio3420 = parametros.declaracion.UtilidadEjercicio3420,
                    TotalPasivos1620 = parametros.declaracion.TotalPasivos,
                    FechaInser = DateTime.Now,
                    RUC = parametros.declaracion.RUC,
                    TotActivoNoCorriente1077 = parametros.declaracion.ActivoNoCorriente,
                    TotalActivo1080 = parametros.declaracion.TotalActivos,
                    TotalActivoCorriente470 = parametros.declaracion.ActivoCorriente,
                    TotalIngresos1930 = parametros.declaracion.Ingresos,
                    TotalPasivosContingente = parametros.declaracion.PasivoContingente,
                    TotalPasivosLargoPlazo1590 = parametros.declaracion.PasivoLargoPlazo,
                    TotasCostosGastos3380 = parametros.declaracion.CostosGastos,
                    TotPasivosCorrientes1340 = parametros.declaracion.PasivoCorriente
                };
                contexto.DeclaracionPJs.Add(declaracion);

                foreach (var item in parametros.Cantones)
                {
                    DistribucionPago distribucion = item.Adapt<DistribucionPago>();
                    distribucion.AnioFiscal = parametros.declaracion.AnioFiscal;
                    distribucion.RUC = parametros.declaracion.RUC;
                    contexto.DistribucionPagos.Add(distribucion);
                }

                await contexto.SaveChangesAsync();
                result.grabado = true;
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
