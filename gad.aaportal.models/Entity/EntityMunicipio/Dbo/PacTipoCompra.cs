using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacTipoCompra
    {
        public PacTipoCompra()
        {
            PacProductos = new HashSet<PacProducto>();
        }

        public int IdTipoCompra { get; set; }
        public string? TipoCompra { get; set; }

        public virtual ICollection<PacProducto> PacProductos { get; set; }
    }
}
