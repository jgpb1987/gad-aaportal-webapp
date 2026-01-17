using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Aplicacion;
using gad.aaportal.models.Entity.Dinardap;
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
                var declaracion = parametros.declaracion.Adapt<DeclaracionPJ>();
                declaracion.FechaInser = DateTime.Now;
                contexto.DeclaracionPJs.Add(declaracion);

                foreach (var item in parametros.Cantones)
                {
                    DistribucionPago distribucion = new DistribucionPago();
                    distribucion.AnioFiscal = parametros.declaracion.AnioFiscal;
                    distribucion.RUC = parametros.declaracion.RUC;
                    distribucion.Canton = item.Id;
                    distribucion.Porcentaje = item.Porcentaje;
                    distribucion.Paga = item.PagoAA;

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
