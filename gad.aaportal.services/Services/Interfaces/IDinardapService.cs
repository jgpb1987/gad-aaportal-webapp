using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDinardapService
    {
        Task<bool> SaveForm101(AaportalContext contexto, ListForm101 form101);
        Task<bool> SaveForm102(AaportalContext contexto, ListForm102 form102);
        Task<bool> SavePaquete7728(AaportalContext contexto, Lista7728 paquete7728);
        Task<bool> SavePaquete7730(AaportalContext contexto, Lista7730 paquete7730);
    }
}
