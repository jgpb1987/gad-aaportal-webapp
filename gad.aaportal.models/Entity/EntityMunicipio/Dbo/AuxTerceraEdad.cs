using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AuxTerceraEdad
    {
        public int IdAuxTerceraEdad { get; set; }
        public string? Cedula { get; set; }
        public int? Porcentaje { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Anio { get; set; }
    }
}
