using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApDatosIngresoLaboratorio
    {
        public int CodigoAnalisis { get; set; }
        public string? LugarMuestreo { get; set; }
        public string? DireccionMuestreo { get; set; }
        public DateTime? FechaMuestreo { get; set; }
        public DateTime? FechaAnalisis { get; set; }
        public string? Usuario { get; set; }
        public string? HoraMuestreo { get; set; }
        public string? Parroquia { get; set; }
        public string? Sector { get; set; }
        public string? Observacion { get; set; }
    }
}
