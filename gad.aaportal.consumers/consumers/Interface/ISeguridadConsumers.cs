using gad.aaportal.commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Interface
{
    public interface ISeguridadConsumers
    {
        public Task<RsaDtoResult> GetPublicKey();
        public Task<UsuarioDtoResult> Login(UsuarioDtoParam parametro);
    }
}
