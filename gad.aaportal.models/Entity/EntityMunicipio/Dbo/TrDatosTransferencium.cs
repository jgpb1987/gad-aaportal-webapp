using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrDatosTransferencium
    {
        public int CodigoDatosTransferencia { get; set; }
        public int CodigoTransferencia { get; set; }
        public string CodigoCliente { get; set; } = null!;
        public string TipoTransaccion { get; set; } = null!;
        public double Valor { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Comentario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public double? TasaInteres { get; set; }
        public double? BaseImponible { get; set; }
        public int NroAlcabala { get; set; }
        public double? OtrosUtilidadUrbana { get; set; }
        public int? TerceraEdad { get; set; }
        public int? CodigoDatosIngreso { get; set; }

        public virtual TrDiferenciasValor CodigoDatosTransferenciaNavigation { get; set; } = null!;
    }
}
