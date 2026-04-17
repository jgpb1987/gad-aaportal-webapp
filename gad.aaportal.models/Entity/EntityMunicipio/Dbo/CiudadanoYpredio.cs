using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CiudadanoYpredio
    {
        public string? ClaveCat { get; set; }
        public string CedIdentCiudadano { get; set; } = null!;
        public string? Nombres { get; set; }
    }
}
