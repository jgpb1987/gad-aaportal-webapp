using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Configuration.Seguridad
{
    public class Rsa
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string PrivateKey { get; set; } = null!;

        public string PublicKey { get; set; } = null!;

        public bool Estado { get; set; }
    }
}
