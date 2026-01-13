using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Configuration.Seguridad
{
    public class Jwt
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string SecurityKey { get; set; } = null!;

        public int JwtTime { get; set; }

        public bool Estado { get; set; }
    }
}
