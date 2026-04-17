using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacDescripcionCompraProducto
    {
        public PacDescripcionCompraProducto()
        {
            PacProductos = new HashSet<PacProducto>();
        }

        public int IdDescripcion { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<PacProducto> PacProductos { get; set; }
    }
}
