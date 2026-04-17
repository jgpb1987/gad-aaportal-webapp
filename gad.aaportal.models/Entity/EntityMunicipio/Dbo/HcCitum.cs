using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcCitum
    {
        public int CitaId { get; set; }
        public DateTime CitaFecha { get; set; }
        public string? CitaObs { get; set; }
        public string CitaCed { get; set; } = null!;

        public virtual Empleado CitaCedNavigation { get; set; } = null!;
    }
}
