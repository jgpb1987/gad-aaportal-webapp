using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DivPol
    {
        public DivPol()
        {
            Sectores = new HashSet<Sectore>();
            Ubicacions = new HashSet<Ubicacion>();
        }

        public string Coddivpol { get; set; } = null!;
        public string? Coddivpolpad { get; set; }
        public string? Nomdivpol { get; set; }
        public string? Codubi { get; set; }

        public virtual ICollection<Sectore> Sectores { get; set; }
        public virtual ICollection<Ubicacion> Ubicacions { get; set; }
    }
}
