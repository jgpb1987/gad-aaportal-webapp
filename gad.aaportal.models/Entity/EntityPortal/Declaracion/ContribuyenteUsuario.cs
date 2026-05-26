using gad.aaportal.models.Entity.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class ContribuyenteUsuario
    {
        public string Identificacion { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public virtual Contribuyente IdentificacionNavigation { get; set; } = null!;
        public virtual Usuario UsuarioNavigation { get; set; } = null!;
    }
}
