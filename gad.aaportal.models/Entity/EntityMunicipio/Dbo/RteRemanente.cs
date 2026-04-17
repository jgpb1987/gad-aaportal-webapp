using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteRemanente
    {
        public int CodigoRemanente { get; set; }
        public int CodigoEspectaculo { get; set; }
        public int? CodigoDescripcion { get; set; }
        public int? Legajos { get; set; }
        public int? Del { get; set; }
        public int? Al { get; set; }
        public double? Precio { get; set; }
        public string? Estado { get; set; }
    }
}
