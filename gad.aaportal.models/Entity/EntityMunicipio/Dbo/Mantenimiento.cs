using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Mantenimiento
    {
        public int IdVehiculo { get; set; }
        public float? KmMantenimiento { get; set; }
        public float? KmAcum { get; set; }
        public float? KmIndicador { get; set; }
        public string? KmEstado { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
