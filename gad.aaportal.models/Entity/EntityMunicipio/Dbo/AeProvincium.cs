using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeProvincium
    {
        public AeProvincium()
        {
            AeCantons = new HashSet<AeCanton>();
        }

        public int IdProvincia { get; set; }
        public string? Provincia { get; set; }

        public virtual ICollection<AeCanton> AeCantons { get; set; }
    }
}
