using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AspnetPersonalizationAllUser
    {
        public Guid PathId { get; set; }
        public byte[] PageSettings { get; set; } = null!;
        public DateTime LastUpdatedDate { get; set; }

        public virtual AspnetPath Path { get; set; } = null!;
    }
}
