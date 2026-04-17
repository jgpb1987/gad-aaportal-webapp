using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClaseProducto
    {
        public ClaseProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
