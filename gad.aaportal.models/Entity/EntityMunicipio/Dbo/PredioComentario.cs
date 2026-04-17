using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioComentario
    {
        public int IdComentario { get; set; }
        public string? Comentario { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? CodCatastralPredio { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
    }
}
