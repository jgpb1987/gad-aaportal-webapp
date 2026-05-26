using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class ContribuyenteServices : IContribuyenteServices
    {
        private readonly ILogger<ContribuyenteServices> logger;
        public ContribuyenteServices(ILogger<ContribuyenteServices> logger)
        {
            this.logger = logger;
        }
        public async Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(AaportalContext contexto, ContribuyenteResumenDtoParam parametro)
        {
            ContribuyenteResumenDataDtoResult result = new();
            try
            {
                result.Data = await contexto.Contribuyentes.Where(c => c.Identificacion == parametro.Identificacion)
                    .Select(c => new ContribuyenteResumenDtoResult
                    {
                        Identificacion = c.Identificacion,
                        RazonSocial = c.RazonSocial,
                        TipoContribuyente = c.TipoContribuyente,
                        ActividadEconomica = c.ActividadEconomicaPrincipal,
                        InicioActividadEconomica = c.FechaInicioActividades.ToString("dd-MM-yyyy"),
                        ContribuyenteEspecial = c.ContribuyenteEspecial,
                        ObligadoLlevarContabilidad = c.ObligadoLlevarContabilidad
                    }).FirstOrDefaultAsync();
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
    }
}
