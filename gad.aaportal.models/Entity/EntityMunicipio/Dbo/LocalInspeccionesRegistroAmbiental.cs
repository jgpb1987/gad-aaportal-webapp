using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalInspeccionesRegistroAmbiental
    {
        public int IdInspeccion { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaMax { get; set; }
        public int? IdLocal { get; set; }
        public string? Estado { get; set; }
        public string? AsignadoPor { get; set; }
        public string? AsignadoA { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaInspeccionarHasta { get; set; }
    }
}
