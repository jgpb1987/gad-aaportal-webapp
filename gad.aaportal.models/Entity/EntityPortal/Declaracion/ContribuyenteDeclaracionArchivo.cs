using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class ContribuyenteDeclaracionArchivo
    {
        public long Id { get; set; }
        public long IdContribuyenteDeclaracion { get; set; }
        public DateTime FechaHora { get; set; }
        public string UbicacionArchivo { get; set; } = null!;
        public string NombreArchivo { get; set; } = null!;
        public string ExtensionArchivo { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ContribuyenteDeclaracion IdContribuyenteDeclaracionNavigation { get; set; } = null!;
    }
}
