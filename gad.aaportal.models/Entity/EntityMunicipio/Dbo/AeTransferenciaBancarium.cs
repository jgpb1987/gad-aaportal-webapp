using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeTransferenciaBancarium
    {
        public AeTransferenciaBancarium()
        {
            AeActivosTotalesPendientes = new HashSet<AeActivosTotalesPendiente>();
        }

        public int IdTransferencia { get; set; }
        public string? Canton { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? FormaPago { get; set; }
        public string? NroDocumento { get; set; }
        public double? Valor { get; set; }
        public string? UsuarioIngreso { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Banco { get; set; }

        public virtual ICollection<AeActivosTotalesPendiente> AeActivosTotalesPendientes { get; set; }
    }
}
