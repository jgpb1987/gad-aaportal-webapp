using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTramitesConcluido
    {
        public int NumeroDeTramite { get; set; }
        public string Para { get; set; } = null!;
        public string NombreAdicional { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Asunto { get; set; } = null!;
        public DateTime? FechaDeIngreso { get; set; }
        public string? NumeroDeDocumento { get; set; }
        public string? Externo { get; set; }
        public string TipoTramite { get; set; } = null!;
        public string? SecuenciaDelFlujo { get; set; }
        public DateTime? FechaDeRegistro { get; set; }
        public string AsuntoMemo { get; set; } = null!;
        public string? TipoTramite2 { get; set; }
        public string? Usuario { get; set; }
        public DateTime? ConcluidoFecha { get; set; }
    }
}
