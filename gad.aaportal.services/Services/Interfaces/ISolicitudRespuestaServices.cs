using gad.aaportal.commons.Dto.Log;
using gad.aaportal.dataaccess;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface ISolicitudRespuestaServices
    {
        public Task<LogResult> GenerarLogApis(AaportalContext contexto, LogParam parametro);
    }
}
