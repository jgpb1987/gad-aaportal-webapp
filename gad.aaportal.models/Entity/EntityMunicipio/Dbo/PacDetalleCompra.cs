using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacDetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public double PrecioUnitarioDetalleCompra { get; set; }
        public int CantidadDetalleCompra { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public string? Observacion { get; set; }

        public virtual PacCompra IdCompraNavigation { get; set; } = null!;
        public virtual PacProducto IdProductoNavigation { get; set; } = null!;
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
