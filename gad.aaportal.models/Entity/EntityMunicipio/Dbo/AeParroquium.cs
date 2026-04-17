using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeParroquium
    {
        public int IdParroquia { get; set; }
        public int? IdCanton { get; set; }
        public string? Parroquia { get; set; }

        public virtual AeCanton? IdCantonNavigation { get; set; }
    }
}
