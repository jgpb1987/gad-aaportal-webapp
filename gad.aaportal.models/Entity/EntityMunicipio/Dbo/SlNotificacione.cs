using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlNotificacione
    {
        public int IdNotificacion { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string? Usuario { get; set; }
    }
}
