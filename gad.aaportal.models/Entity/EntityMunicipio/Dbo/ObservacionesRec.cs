using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ObservacionesRec
    {
        public int CodigoObservacionRec { get; set; }
        public int CodIngresoOrec { get; set; }
        public string? TipoObservacionOrec { get; set; }
        public string ComentarioOrec { get; set; } = null!;
        public DateTime FechaOrec { get; set; }
        public string? Numero { get; set; }
        public string UsuarioOrec { get; set; } = null!;
        public string? Recaudador { get; set; }
        public int? NumTramite { get; set; }
        public double? Valor { get; set; }
        public int? NumeroTituloOrec { get; set; }
    }
}
