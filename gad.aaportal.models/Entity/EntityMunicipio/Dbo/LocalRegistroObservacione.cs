using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalRegistroObservacione
    {
        public int IdObservaciones { get; set; }
        public string? Observaciones { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Ruc { get; set; }
        public int? IdLocal { get; set; }
    }
}
