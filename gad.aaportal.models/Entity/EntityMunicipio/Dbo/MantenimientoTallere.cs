using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoTallere
    {
        public MantenimientoTallere()
        {
            MantenimientoDetalles = new HashSet<MantenimientoDetalle>();
        }

        public int IdTaller { get; set; }
        public string? NombreTaller { get; set; }

        public virtual ICollection<MantenimientoDetalle> MantenimientoDetalles { get; set; }
    }
}
