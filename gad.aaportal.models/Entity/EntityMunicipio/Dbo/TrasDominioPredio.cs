using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrasDominioPredio
    {
        public string? CodCatastralPredio { get; set; }
        public int? CodTrasDominio { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual TrasDominio? CodTrasDominioNavigation { get; set; }
    }
}
