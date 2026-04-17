using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtTipoTarjetum
    {
        public RtTipoTarjetum()
        {
            RtPagoTarjeta = new HashSet<RtPagoTarjetum>();
        }

        public int Codigo { get; set; }
        public string CodigoTipoTarjeta { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? EstadoTipoTarjeta { get; set; }
        public string? Banco { get; set; }

        public virtual ICollection<RtPagoTarjetum> RtPagoTarjeta { get; set; }
    }
}
