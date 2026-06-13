using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Util
{
    public class SubirDeclaracionArchivoDtoParam
    {
        public long IdContribuyenteDeclaracion { get; set; }

        public IFormFile Archivo { get; set; } = default!;
    }
}
