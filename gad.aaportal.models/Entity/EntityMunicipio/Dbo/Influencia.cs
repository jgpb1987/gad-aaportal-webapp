using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Influencia
    {
        public Influencia()
        {
            ClaseTierras = new HashSet<ClaseTierra>();
        }

        public int CodInfluencias { get; set; }
        public string? DescripcionInfluencias { get; set; }
        public string? Coddivpol { get; set; }
        public decimal? ZonHoPrecioBase { get; set; }
        public int? CodOrdenar { get; set; }

        public virtual ICollection<ClaseTierra> ClaseTierras { get; set; }
    }
}
