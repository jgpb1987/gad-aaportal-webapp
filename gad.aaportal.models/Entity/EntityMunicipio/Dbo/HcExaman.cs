using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcExaman
    {
        public int ExId { get; set; }
        public string? ExPiel { get; set; }
        public string? ExTcs { get; set; }
        public string? ExAr { get; set; }
        public string? ExAcv { get; set; }
        public string? ExAbd { get; set; }
        public string? ExSnc { get; set; }
        public string ExCed { get; set; } = null!;
        public DateTime ExFecha { get; set; }

        public virtual Empleado ExCedNavigation { get; set; } = null!;
    }
}
