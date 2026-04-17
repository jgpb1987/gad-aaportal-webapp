using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TePrestamosAnio
    {
        public int IdPrestamoAnio { get; set; }
        public int? IdPrestamo { get; set; }
        public double? ValorPropiedadAnio { get; set; }
        public double? SaldoCapital { get; set; }
        public string? TipoPredio { get; set; }
        public double? ValorPropiedadLim { get; set; }
        public double? ValorDeduccion { get; set; }
        public int? Anio { get; set; }
        public double? Porcentaje { get; set; }
        public double? ValorAplicadoPorcentaje { get; set; }

        public virtual TeInfoPrestamosHipotecario? IdPrestamoNavigation { get; set; }
    }
}
