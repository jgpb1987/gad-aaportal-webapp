using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CiudadanosEliminado
    {
        public string CedIdentCiudadano { get; set; } = null!;
        public string? ApellidosCiudadano { get; set; }
        public string? NombresCiudadano { get; set; }
        public string? DireccionCiudadano { get; set; }
        public DateTime? FechaNacCiudadano { get; set; }
        public int? TerceraEdad { get; set; }
    }
}
