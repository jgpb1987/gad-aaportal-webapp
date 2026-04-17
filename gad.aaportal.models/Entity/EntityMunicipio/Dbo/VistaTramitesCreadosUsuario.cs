using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTramitesCreadosUsuario
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
        public string? Usuario { get; set; }
        public int Secuencia { get; set; }
        public string? PredioClave { get; set; }
    }
}
