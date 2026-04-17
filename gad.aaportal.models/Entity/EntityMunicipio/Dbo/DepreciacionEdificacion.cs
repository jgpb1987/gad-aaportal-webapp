using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DepreciacionEdificacion
    {
        public int CodDepreciacionEdificacion { get; set; }
        public int? CodClaseDescrEdif1 { get; set; }
        public int? CodClaseDescrEdif2 { get; set; }
        public int? CodClaseDescrEdif3 { get; set; }
        public int? CodClaseDescrEdifEd { get; set; }
        public double? CoefDepreciacionEdificacion { get; set; }
        public double? CoefDepreciacionEdificacion111 { get; set; }
    }
}
