using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmObservacione
    {
        public int IdObservacion { get; set; }
        public string? Observacion { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int? CodigoObra { get; set; }

        public virtual SmObra? CodigoObraNavigation { get; set; }
    }
}
