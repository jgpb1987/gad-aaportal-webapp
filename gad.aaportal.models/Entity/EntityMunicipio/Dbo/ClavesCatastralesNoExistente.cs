using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClavesCatastralesNoExistente
    {
        public string? Clave { get; set; }
        public string? Cedula { get; set; }
        public bool? Emitido { get; set; }
        public string? EmitidoEn { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
