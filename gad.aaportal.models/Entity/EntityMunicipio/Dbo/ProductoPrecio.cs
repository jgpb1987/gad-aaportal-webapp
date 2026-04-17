using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ProductoPrecio
    {
        public int IdProductoPrecio { get; set; }
        public int? CodigoProducto { get; set; }
        public double? Precio { get; set; }
        public double? PrecioConIva { get; set; }

        public virtual Producto? CodigoProductoNavigation { get; set; }
    }
}
