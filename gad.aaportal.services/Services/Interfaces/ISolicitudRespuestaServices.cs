using gad.aaportal.commons.Dto.Log;
using gad.aaportal.dataaccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface ISolicitudRespuestaServices
    {
        public Task<LogResult> GenerarLogApis(AaportalContext contexto, LogParam parametro);
    }
}
