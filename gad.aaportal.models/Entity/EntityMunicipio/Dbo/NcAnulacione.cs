using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcAnulacione
    {
        public int IdAnulacion { get; set; }
        public string? Observacion { get; set; }
        public int? NotaCredito { get; set; }
        public string? Usuario { get; set; }
        public DateTime? FechaAnulacion { get; set; }
    }
}
