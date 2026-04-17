using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VwAspnetProfile
    {
        public Guid UserId { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int? DataSize { get; set; }
    }
}
