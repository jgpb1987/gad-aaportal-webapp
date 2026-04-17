using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtPagoTarjetum
    {
        public int CodigoPagoTarjeta { get; set; }
        public int? CodigoDatosIngreso { get; set; }
        public string? NumeroPagoTarjeta { get; set; }
        public string? NumeroVaucherPagoTarjeta { get; set; }
        public string? CodigoTipoTarjeta { get; set; }
        public string? EstadoTipoTarjeta { get; set; }

        public virtual DatosIngreso? CodigoDatosIngresoNavigation { get; set; }
        public virtual RtTipoTarjetum? CodigoTipoTarjetaNavigation { get; set; }
    }
}
