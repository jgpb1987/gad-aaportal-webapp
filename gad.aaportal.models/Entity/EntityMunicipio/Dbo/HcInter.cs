using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcInter
    {
        public int InterId { get; set; }
        public string? InterAcv { get; set; }
        public string? InterAr { get; set; }
        public string? InterAd { get; set; }
        public string? InterAu { get; set; }
        public string? InterSoma { get; set; }
        public string InterCed { get; set; } = null!;
        public DateTime? InterFecha { get; set; }
        public string? InterVaz { get; set; }
        public string? InterSnc { get; set; }

        public virtual Empleado InterCedNavigation { get; set; } = null!;
    }
}
