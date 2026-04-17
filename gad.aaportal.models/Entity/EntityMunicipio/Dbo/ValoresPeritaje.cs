using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValoresPeritaje
    {
        public int IdPeritaje { get; set; }
        public DateTime? Fecha { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorEdificacion { get; set; }
        public double? ValorPropiedad { get; set; }
        public string? Usuario { get; set; }
        public string? CodCatastralPredio { get; set; }
        public string? Comentario { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
    }
}
