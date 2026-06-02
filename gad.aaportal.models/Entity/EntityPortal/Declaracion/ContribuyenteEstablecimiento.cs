using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Declaracion
{
    public class ContribuyenteEstablecimiento
    {
        public long Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string NombreFantasiaComercial { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Calles { get; set; } = null!;
        public string DireccionCompleta { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string NumeroEstablecimiento { get; set; } = null!;
        public string Matriz { get; set; } = null!;

        public virtual Contribuyente IdentificacionNavigation { get; set; } = null!;
    }
}
