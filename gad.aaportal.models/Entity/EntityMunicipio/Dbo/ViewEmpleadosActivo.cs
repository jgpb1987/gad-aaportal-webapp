using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ViewEmpleadosActivo
    {
        public string? Cargo { get; set; }
        public string? Denominacion { get; set; }
        public string? Estado { get; set; }
        public string CedIdentCiudadano { get; set; } = null!;
    }
}
