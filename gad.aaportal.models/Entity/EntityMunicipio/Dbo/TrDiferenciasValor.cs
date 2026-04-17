using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrDiferenciasValor
    {
        public int CodigoDatosTransferencia { get; set; }
        public int? CodigoDescripcion { get; set; }
        public double? ValorOtroCanton { get; set; }
        public double? ValorIbarra { get; set; }
        public int? Orden { get; set; }

        public virtual TrDatosTransferencium? TrDatosTransferencium { get; set; }
    }
}
