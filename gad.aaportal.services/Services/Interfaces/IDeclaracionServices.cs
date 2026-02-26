using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IDeclaracionServices
    {
        Task<SaveDeclaracionPJResult> GrabarDeclaracionPJ(AaportalContext contexto, DeclaracionRequest declaracion);

    }
}
