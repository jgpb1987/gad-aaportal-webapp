using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DivPolAnt
    {
        public DivPolAnt()
        {
            TrNotaria = new HashSet<TrNotarium>();
        }

        public string Coddivpol { get; set; } = null!;
        public string? Coddivpolpad { get; set; }
        public string Nomdivpol { get; set; } = null!;
        public string? Tipdivpol { get; set; }
        public string? Codubi { get; set; }

        public virtual ICollection<TrNotarium> TrNotaria { get; set; }
    }
}
