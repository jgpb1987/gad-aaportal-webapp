using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcEndoso
    {
        public int IdEndoso { get; set; }
        public int? IdNotaCredito { get; set; }
        public double? ValorEndoso { get; set; }
        public string? Beneficiario { get; set; }
        public string? Propietario { get; set; }
        public string? AutorizadoPor { get; set; }
        public string? UsuarioReg { get; set; }
        public DateTime? FechaEndoso { get; set; }

        public virtual NcNotaCredito? IdNotaCreditoNavigation { get; set; }
    }
}
