using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.models.Entity.Dinardap;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace gad.aaportal.services.Services.Implementation
{
    public class DinardapService : IDinardapService
    {
        private readonly ILogger<DinardapService> logger;

        public DinardapService(ILogger<DinardapService> logger)
        {
            this.logger = logger;
        }

        public async Task<Form101SaveDtoResult> SaveDinardapResult(AaportalContext contexto, Form101DtoRequest form101)
        {
            Form101SaveDtoResult result = new Form101SaveDtoResult();
            try
            {
                var entity = form101.Adapt<Form101>();
                entity.FechaInsert = DateTime.Now;
                contexto.Form101.Add(entity);
                await contexto.SaveChangesAsync();
                result.Result = true;
            }
            catch (Exception ex)
            {
                //logger.LogError(sex, sex.Description, sex.Code);
                //throw;
            }
            return result;
        }

        public async Task<Form101SaveDtoResult> UpdateDinardapResult(AaportalContext contexto, Form101DtoRequest form101)
        {
            Form101SaveDtoResult result = new Form101SaveDtoResult();
            try
            {
                var entity = form101.Adapt<Form101>();
                if (entity.AnioFiscal == 2010)
                {
                    string pausa=string.Empty;
                }
                var reg = contexto.Form101.Where(f => f.AnioFiscal == entity.AnioFiscal &&
                                        f.NumeroIdentificacion == entity.NumeroIdentificacion).FirstOrDefault();
                if (reg != null)
                {
                    form101.Adapt(reg);
                    reg.FechaModificado = DateTime.Now;
                }
                await contexto.SaveChangesAsync();
                result.Result = true;
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
