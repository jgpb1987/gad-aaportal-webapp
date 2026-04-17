using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApTipodetarifa
    {
        public ApTipodetarifa()
        {
            ApAcometida = new HashSet<ApAcometida>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<ApAcometida> ApAcometida { get; set; }
    }
}
