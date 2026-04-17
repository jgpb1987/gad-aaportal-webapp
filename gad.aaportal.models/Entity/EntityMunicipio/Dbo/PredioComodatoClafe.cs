using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioComodatoClafe
    {
        public int IdComodato { get; set; }
        public string ClaveCatastral { get; set; } = null!;
        public string? Estado { get; set; }
    }
}
