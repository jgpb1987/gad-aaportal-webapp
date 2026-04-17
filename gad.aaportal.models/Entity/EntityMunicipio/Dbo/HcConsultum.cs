using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcConsultum
    {
        public int ConsId { get; set; }
        public string? ConsMotivo { get; set; }
        public string ConsHea { get; set; } = null!;
        public DateTime ConsFecha { get; set; }
        public string ConsCed { get; set; } = null!;

        public virtual Empleado ConsCedNavigation { get; set; } = null!;
    }
}
