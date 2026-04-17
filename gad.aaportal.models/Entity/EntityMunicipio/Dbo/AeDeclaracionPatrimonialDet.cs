using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeDeclaracionPatrimonialDet
    {
        public int? IdDeclaracion { get; set; }
        public string? CiPropietario { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? ValorPropiedad { get; set; }

        public virtual AeDeclaracionPatrimonialCab? IdDeclaracionNavigation { get; set; }
    }
}
