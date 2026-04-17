using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TePrestamoTipoDeduccion
    {
        public TePrestamoTipoDeduccion()
        {
            TeInfoPrestamosHipotecarios = new HashSet<TeInfoPrestamosHipotecario>();
        }

        public int IdTipoDeduccion { get; set; }
        public string? Descripcion { get; set; }
        public string? Articulo { get; set; }
        public int? Plazo { get; set; }
        public string? AplicaPorcentaje { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<TeInfoPrestamosHipotecario> TeInfoPrestamosHipotecarios { get; set; }
    }
}
