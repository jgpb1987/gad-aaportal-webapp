using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioInfoCensalComplementario
    {
        public string? ClaveCatastral { get; set; }
        public string? CondicionesOcupacionales { get; set; }
        public string? TipoVivienda { get; set; }
        public double? EspacioBanio { get; set; }
        public double? NroFamilia { get; set; }
        public string? BienMonstrenco { get; set; }
        public string? ValorCultural { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
    }
}
