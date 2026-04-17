using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcMovimiento
    {
        public int IdMovimientos { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public double? Valor { get; set; }
        public double? Saldo { get; set; }
        public string? UsuarioIngreso { get; set; }
        public int? IdNotaCredito { get; set; }
        public int? CodigoIngreso { get; set; }
        public string? EstadoTrans { get; set; }
        public string? Reingreso { get; set; }

        public virtual NcNotaCredito? IdNotaCreditoNavigation { get; set; }
    }
}
