using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class HcCertificado
    {
        public int CerId { get; set; }
        public string CerCed { get; set; } = null!;
        public DateTime CerFecha { get; set; }
        public string CerHoras { get; set; } = null!;
        public string CerObs { get; set; } = null!;
        public int CerDg { get; set; }

        public virtual HcDiagnostico Cer { get; set; } = null!;
        public virtual Empleado CerCedNavigation { get; set; } = null!;
    }
}
