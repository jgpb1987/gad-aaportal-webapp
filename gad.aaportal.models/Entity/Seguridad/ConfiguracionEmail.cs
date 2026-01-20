using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Seguridad
{
    public class ConfiguracionEmail
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Servidor { get; set; } = null!;

        public string Puerto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Pwd { get; set; } = null!;

        public bool Estado { get; set; }
    }
}
