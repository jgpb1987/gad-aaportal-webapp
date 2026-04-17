using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlClasificacion
    {
        public int IdClasificacion { get; set; }
        public string? Descripcion { get; set; }
        public int? IdActividad { get; set; }
        public string? Estado { get; set; }

        public virtual SlActividad? IdActividadNavigation { get; set; }
    }
}
