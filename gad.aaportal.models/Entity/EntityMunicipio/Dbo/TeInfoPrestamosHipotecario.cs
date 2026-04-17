using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeInfoPrestamosHipotecario
    {
        public TeInfoPrestamosHipotecario()
        {
            TePrestamosAnios = new HashSet<TePrestamosAnio>();
        }

        public int IdInfo { get; set; }
        public int? IdExoneracionPersona { get; set; }
        public int? TipoDeduccion { get; set; }
        public string? TipoPrestamo { get; set; }
        public string? Institucion { get; set; }
        public DateTime? FechaConsecionCredito { get; set; }
        public DateTime? FechaFinCredito { get; set; }
        public int? PlazoMeses { get; set; }
        public int? PlazoAnio { get; set; }
        public double? ValorPrestamo1 { get; set; }
        public double? ValorPrestamo2 { get; set; }
        public double? ValorPrestamoCapital { get; set; }
        public string? ClaveCatastral { get; set; }

        public virtual TeExoneracionesPersona? IdExoneracionPersonaNavigation { get; set; }
        public virtual TePrestamoTipoDeduccion? TipoDeduccionNavigation { get; set; }
        public virtual ICollection<TePrestamosAnio> TePrestamosAnios { get; set; }
    }
}
