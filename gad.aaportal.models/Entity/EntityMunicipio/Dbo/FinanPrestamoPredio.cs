using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class FinanPrestamoPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public int? CodFinanPrestamo { get; set; }
        public string? PreHiCodigo { get; set; }
        public decimal? MontoPrestamo { get; set; }
        public DateTime? FechaConsecionPrestamo { get; set; }
        public int? PlazoPrestamo { get; set; }
        public string? PreHiEntidad { get; set; }
        public decimal? PorcentajeExonPrestamo { get; set; }
        public int Numerico { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
        public virtual FinanPrestamo? CodFinanPrestamoNavigation { get; set; }
    }
}
