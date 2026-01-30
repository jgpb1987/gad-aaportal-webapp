using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDinardapService
    {
        Task<bool> SaveForm101(AaportalContext contexto, ListForm101 form101);
        Task<bool> SaveForm102(AaportalContext contexto, ListForm102 form102);
    }
}
