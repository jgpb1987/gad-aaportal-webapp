using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoTipoRepuesto
    {
        public MantenimientoTipoRepuesto()
        {
            MantenimientoRepuestos = new HashSet<MantenimientoRepuesto>();
        }

        public int IdTipo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<MantenimientoRepuesto> MantenimientoRepuestos { get; set; }
    }
}
