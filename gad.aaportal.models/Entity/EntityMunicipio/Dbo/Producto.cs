using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoPrecios = new HashSet<ProductoPrecio>();
        }

        public int Codigo { get; set; }
        public int CodigoClaseProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public double? PrecioUnitario { get; set; }
        public double? PrecioUnitarioPago { get; set; }
        public bool? EstadoProd { get; set; }

        public virtual ClaseProducto CodigoClaseProductoNavigation { get; set; } = null!;
        public virtual ICollection<ProductoPrecio> ProductoPrecios { get; set; }
    }
}
