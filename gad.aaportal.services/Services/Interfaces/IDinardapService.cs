using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDinardapService
    {
        Task<Form101SaveDtoResult> SaveDinardapResult(AaportalContext contexto, Form101DtoRequest form101);
        Task<Form101SaveDtoResult> UpdateDinardapResult(AaportalContext contexto, Form101DtoRequest form101);
    }
}
