using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioFrente
    {
        public int Id { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CalleAledania { get; set; }
        public double? Frente { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
    }
}
