using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MantenimientoMovimiento
    {
        public int IdVehiculo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? KmEstado { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
