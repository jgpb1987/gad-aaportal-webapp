using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeTransfPendienteDecla
    {
        public int IdTrans { get; set; }
        public string? Ruc { get; set; }
        public double? ValorTransferido { get; set; }
        public double? Comision { get; set; }
        public double? TotalImpuesto { get; set; }
        public string? Gad { get; set; }
        public DateTime? FechaTransferencia { get; set; }
        public string? NroReferencia { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Estado { get; set; }
    }
}
