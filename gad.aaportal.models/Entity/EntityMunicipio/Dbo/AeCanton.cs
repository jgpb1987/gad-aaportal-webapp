using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeCanton
    {
        public AeCanton()
        {
            AeParroquia = new HashSet<AeParroquium>();
        }

        public int IdCanton { get; set; }
        public int? IdProvincia { get; set; }
        public string? Canton { get; set; }

        public virtual AeProvincium? IdProvinciaNavigation { get; set; }
        public virtual ICollection<AeParroquium> AeParroquia { get; set; }
    }
}
