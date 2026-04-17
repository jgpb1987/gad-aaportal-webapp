using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ConvenioAdoquinado
    {
        public DateTime? FechaConv { get; set; }
        public string Nroconv { get; set; } = null!;
        public double? Nrocont { get; set; }
        public string? Destino { get; set; }
        public string? Obra { get; set; }
        public string? Calle { get; set; }
        public string? Entre { get; set; }
        public DateTime? FechaI { get; set; }
        public string? Plazo { get; set; }
        public string? Finan { get; set; }
        public double? Valor { get; set; }
        public string? OfIng { get; set; }
    }
}
