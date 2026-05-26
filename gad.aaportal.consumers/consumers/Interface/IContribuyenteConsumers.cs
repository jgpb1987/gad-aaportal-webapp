using gad.aaportal.commons.Dto.Declaracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface IContribuyenteConsumers
    {
        Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(ContribuyenteResumenDtoParam parametro);
    }
}
