using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Predios = new HashSet<Predio>();
        }

        public string UbiCodigo { get; set; } = null!;
        public string? UbiCodigoPadre { get; set; }
        public string? UbiDescripcion { get; set; }
        public string? DivPoCodigo { get; set; }

        public virtual DivPol? DivPoCodigoNavigation { get; set; }
        public virtual ICollection<Predio> Predios { get; set; }
    }
}
