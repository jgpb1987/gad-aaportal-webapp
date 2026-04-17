using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaInspeccionesDenuncia
    {
        public int IdInspeccionDenuncia { get; set; }
        public int? IdDenuncia { get; set; }
        public string? Tipo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? EmpleadoAsignador { get; set; }
        public string? EmpleadoAsignado { get; set; }
        public DateTime? InspeccionarHasta { get; set; }

        public virtual Empleado? EmpleadoAsignadoNavigation { get; set; }
        public virtual Empleado? EmpleadoAsignadorNavigation { get; set; }
    }
}
