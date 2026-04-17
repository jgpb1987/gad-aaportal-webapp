using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsDetalleRegistroDeMovimiento
    {
        public long Codigo { get; set; }
        public long CodigoRegistroMovimientos { get; set; }
        public string Detalle { get; set; } = null!;
        public string ValorAnterior { get; set; } = null!;
        public string? ValorNuevo { get; set; }
        public string TipoDeMovimiento { get; set; } = null!;

        public virtual AsRegistroDeMovimiento CodigoRegistroMovimientosNavigation { get; set; } = null!;
    }
}
