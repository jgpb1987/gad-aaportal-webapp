using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcDiagnostico
    {
        public int DgId { get; set; }
        public string? DgDg { get; set; }
        public string? DgNoso { get; set; }
        public DateTime DgFecha { get; set; }
        public string DgCed { get; set; } = null!;
        public string? DgInd { get; set; }

        public virtual Empleado DgCedNavigation { get; set; } = null!;
        public virtual HcCertificado? HcCertificado { get; set; }
    }
}
