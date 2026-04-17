using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DetalleEntrega
    {
        public string CodigoFacturaEntrega { get; set; } = null!;
        public string CodigoProveedor { get; set; } = null!;
        public int CodigoProducto { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public int? IdProductoPrecio { get; set; }

        public virtual FacturaEntrega CodigoFacturaEntregaNavigation { get; set; } = null!;
        public virtual Producto CodigoProductoNavigation { get; set; } = null!;
        public virtual Proveedor CodigoProveedorNavigation { get; set; } = null!;
    }
}
