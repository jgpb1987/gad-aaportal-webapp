using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteEncuestum
    {
        public int CodEncuesta { get; set; }
        public string? Ci { get; set; }
        public string? Respuesta { get; set; }
        public string? Usuario { get; set; }
        public string? Empresa { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
