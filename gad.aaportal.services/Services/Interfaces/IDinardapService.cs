using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDinardapService
    {
        Task<bool> SaveForm101(AaportalContext contexto, ListForm101 form101);
        Task<bool> SaveForm102(AaportalContext contexto, ListForm102 form102);
        Task<bool> SavePaquete7728(AaportalContext contexto, Lista7728 paquete7728);
        Task<bool> SavePaquete7730(AaportalContext contexto, Lista7730 paquete7730);
        Task<bool> SavePaquete7731(AaportalContext contexto, Lista7731 paquete7731);
        Task<bool> SavePaquete7732(AaportalContext contexto, Lista7732 paquete7732);
        Task<bool> SavePaquete6279(AaportalContext contexto, Lista6279 paquete6279);
        Task<bool> SavePaquete7736(AaportalContext contexto, Lista7736 paquete7736);
        Task<bool> SavePaquete7742(AaportalContext contexto, Lista7742 paquete7742);
        Task<ConsumoDinardapResult> ConsultPackage(AaportalContext contexto, PaqueteDinardapRequest request);
    }
}
