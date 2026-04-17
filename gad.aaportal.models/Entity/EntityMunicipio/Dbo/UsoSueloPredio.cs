using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class UsoSueloPredio
    {
        public string? CodCatastralPredio { get; set; }
        public string? CodClaseUsoSuelo { get; set; }
        public int? NumeroBloque { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual ClaseUsoSuelo? CodClaseUsoSueloNavigation { get; set; }
    }
}
