using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenEmpleado
    {
        public int GemCodigo { get; set; }
        public string EmpCodigo { get; set; } = null!;
        public string GemCedula { get; set; } = null!;
        public string GemNombres { get; set; } = null!;
        public string GemApellidos { get; set; } = null!;
        public DateTime GemFechaing { get; set; }
        public DateTime? GemFultmod { get; set; }
        public string? GemUsuarioultmod { get; set; }
        public int GemEstado { get; set; }
        public string? GemSerie { get; set; }
        public int? GemGenero { get; set; }
        public string? GemTelefono { get; set; }
        public string? GemEmail { get; set; }
        public bool? GemActivo { get; set; }
        public string? GemDescripcion { get; set; }
    }
}
