using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DiasLaborable
    {
        public DateTime Fecha { get; set; }
        public int Laborable { get; set; }
        public string Dia { get; set; } = null!;
        public string? Detalle { get; set; }
    }
}
