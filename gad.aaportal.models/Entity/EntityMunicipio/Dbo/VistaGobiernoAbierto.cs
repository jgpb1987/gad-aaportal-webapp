using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaGobiernoAbierto
    {
        public int NumeroDeTramite { get; set; }
        public DateTime? ConcluidoFecha { get; set; }
        public string? Asunto { get; set; }
        public string? TipoTramite { get; set; }
        public DateTime? FechaDeRegistro { get; set; }
        public string? De { get; set; }
        public string? Para { get; set; }
    }
}
