using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LogAvaluosYcatastro
    {
        public string? CodCatastralPredio { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
        public string? Detalle { get; set; }
    }
}
