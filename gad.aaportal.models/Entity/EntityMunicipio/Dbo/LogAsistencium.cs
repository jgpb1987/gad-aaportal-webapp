using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LogAsistencium
    {
        public string? TipoTrn { get; set; }
        public string? Tabla { get; set; }
        public string? Pk { get; set; }
        public string? Campo { get; set; }
        public string? ValorOriginal { get; set; }
        public string? ValorNuevo { get; set; }
        public DateTime? FechaTrn { get; set; }
        public string? Usuario { get; set; }
    }
}
