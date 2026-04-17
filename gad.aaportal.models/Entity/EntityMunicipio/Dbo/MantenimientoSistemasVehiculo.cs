using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoSistemasVehiculo
    {
        public MantenimientoSistemasVehiculo()
        {
            MantenimientoRepuestos = new HashSet<MantenimientoRepuesto>();
        }

        public int IdMantenimientoSistema { get; set; }
        public string? NombreSistema { get; set; }

        public virtual ICollection<MantenimientoRepuesto> MantenimientoRepuestos { get; set; }
    }
}
