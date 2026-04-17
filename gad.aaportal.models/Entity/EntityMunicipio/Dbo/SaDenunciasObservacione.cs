using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaDenunciasObservacione
    {
        public int IdDenunciasObservaciones { get; set; }
        public string? Observaciones { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdDenuncia { get; set; }
        public string? Tipo { get; set; }
    }
}
