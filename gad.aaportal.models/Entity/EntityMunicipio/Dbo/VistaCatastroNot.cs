using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaCatastroNot
    {
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public int? CodigoIngreso { get; set; }
        public string? EstadoIngreso { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
