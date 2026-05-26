using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.dataaccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface IContribuyenteServices
    {
        Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(AaportalContext contexto, ContribuyenteResumenDtoParam parametro);
    }
}
