using gad.aaportal.commons.Dto.Externs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface IServicesExternsConsumers
    {
        public Task<List<InfoRucResult>> SearchInfoRucSri(string identificacion);
        public Task<List<InfoEstablecimientoResult>> SearchInfoEstablecimientoSri(string identificacion);
    }
}
