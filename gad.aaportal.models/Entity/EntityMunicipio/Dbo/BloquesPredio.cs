using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class BloquesPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public int NumeroBloquePredio { get; set; }
        public decimal? SuperfConstBloquePredio { get; set; }
        public string? CodTipoConstrucciones { get; set; }
        public int? CodPeriodoEdif { get; set; }
        public int? BloPrEdadReparacion { get; set; }
        public int? NumPisosBloquePredio { get; set; }
        public decimal? SumatIndicesBloquePredio { get; set; }
        public decimal? ValorM2ReposBloquePredio { get; set; }
        public decimal? ValorComerM2BloquePredio { get; set; }
        public decimal? ValorComerEdifBloquePredio { get; set; }
        public int? BloPrPorcentajeReparacion { get; set; }
        public string? ExclusivoOcomunal { get; set; }
        public string? Usuario { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
    }
}
