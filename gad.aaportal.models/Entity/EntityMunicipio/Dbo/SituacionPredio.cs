using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SituacionPredio
    {
        public string? CodCatastralPredio { get; set; }
        public int? CodSituacion { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual Situacion? CodSituacionNavigation { get; set; }
    }
}
