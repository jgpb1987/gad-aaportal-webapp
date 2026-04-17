using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlActividad
    {
        public SlActividad()
        {
            SlClasificacions = new HashSet<SlClasificacion>();
        }

        public int Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<SlClasificacion> SlClasificacions { get; set; }
    }
}
