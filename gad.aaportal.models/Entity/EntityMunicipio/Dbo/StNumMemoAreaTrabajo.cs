using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StNumMemoAreaTrabajo
    {
        public string? CodigoAreaTrabajo { get; set; }
        public string? Anio { get; set; }
        public int? Numero { get; set; }
        public bool? Usado { get; set; }
        public DateTime? Hora { get; set; }

        public virtual AreaTrabajo? CodigoAreaTrabajoNavigation { get; set; }
    }
}
