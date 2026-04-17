using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaLocalesActividadEconomica
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Propio { get; set; } = null!;
        public string Principal { get; set; } = null!;
        public int? NroEstablecimiento { get; set; }
        public DateTime? FechaAperturaLocal { get; set; }
        public string? TelefonoLocal { get; set; }
        public string? EmailLocal { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CallePredio { get; set; }
        public int? IdActividad { get; set; }
    }
}
