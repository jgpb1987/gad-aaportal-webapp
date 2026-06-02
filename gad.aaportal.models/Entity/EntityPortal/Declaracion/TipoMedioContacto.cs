using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class TipoMedioContacto
    {
        public TipoMedioContacto()
        {
            ContribuyenteMedioContactos = new HashSet<ContribuyenteMedioContacto>();
        }

        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<ContribuyenteMedioContacto> ContribuyenteMedioContactos { get; set; }
    }
}
