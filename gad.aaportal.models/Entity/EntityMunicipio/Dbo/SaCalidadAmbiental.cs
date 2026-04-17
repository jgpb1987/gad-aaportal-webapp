using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaCalidadAmbiental
    {
        public SaCalidadAmbiental()
        {
            SaCalidadAmbientalItems = new HashSet<SaCalidadAmbientalItem>();
        }

        public int IdCalidadAmbiental { get; set; }
        public string? CalidadAmbiental { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<SaCalidadAmbientalItem> SaCalidadAmbientalItems { get; set; }
    }
}
