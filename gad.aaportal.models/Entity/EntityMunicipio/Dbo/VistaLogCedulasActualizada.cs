using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaLogCedulasActualizada
    {
        public string? TipoTrn { get; set; }
        public string? Tabla { get; set; }
        public string? Cedula { get; set; }
        public string? Campo { get; set; }
        public string? ValorOriginal { get; set; }
        public string? ValorNuevo { get; set; }
        public DateTime? FechaTrn { get; set; }
    }
}
