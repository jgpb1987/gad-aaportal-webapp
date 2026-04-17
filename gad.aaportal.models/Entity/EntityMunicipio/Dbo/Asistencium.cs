using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Asistencium
    {
        public string Cedula { get; set; } = null!;
        public string? Hora { get; set; }
        public string? Fecha { get; set; }
    }
}
