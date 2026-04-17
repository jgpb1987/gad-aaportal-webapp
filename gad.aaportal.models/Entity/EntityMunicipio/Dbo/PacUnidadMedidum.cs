using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacUnidadMedidum
    {
        public PacUnidadMedidum()
        {
            PacProductos = new HashSet<PacProducto>();
        }

        public int IdUnidadMedida { get; set; }
        public string NombreUnidadMedida { get; set; } = null!;

        public virtual ICollection<PacProducto> PacProductos { get; set; }
    }
}
