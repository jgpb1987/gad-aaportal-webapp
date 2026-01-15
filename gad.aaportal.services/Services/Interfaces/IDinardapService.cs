using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDinardapService
    {
        Task<Form101SaveDtoResult> SaveForm101Result(AaportalContext contexto, Form101DtoRequest form101);
        Task<Form101SaveDtoResult> UpdateForm101Result(AaportalContext contexto, Form101DtoRequest form101);
        Task<Form102SaveDtoResult> SaveForm102Result(AaportalContext contexto, Form102DtoRequest form102);
        Task<Form102SaveDtoResult> UpdateForm102Result(AaportalContext contexto, Form102DtoRequest form101);
    }
}
