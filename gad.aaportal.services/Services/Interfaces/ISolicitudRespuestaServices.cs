using gad.aaportal.commons.Dto.Log;
using gad.aaportal.dataaccess.Configuration;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface ISolicitudRespuestaServices
    {
        public Task<LogResult> GenerarLogApis(LogParam parametro);
    }
}
