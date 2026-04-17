using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AspnetSchemaVersion
    {
        public string Feature { get; set; } = null!;
        public string CompatibleSchemaVersion { get; set; } = null!;
        public bool IsCurrentVersion { get; set; }
    }
}
