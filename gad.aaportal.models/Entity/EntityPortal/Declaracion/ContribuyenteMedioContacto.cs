using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class ContribuyenteMedioContacto
    {
        public long IdMedioContacto { get; set; }
        public string Identificacion { get; set; } = null!;
        public string CodigoTipoMedioContacto { get; set; } = null!;
        public string Valor { get; set; } = null!;
        public bool EsPrincipal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public virtual TipoMedioContacto CodigoTipoMedioContactoNavigation { get; set; } = null!;
        public virtual Contribuyente IdentificacionNavigation { get; set; } = null!;
    }
}
