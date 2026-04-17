using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RegistroMovimientosGasolina
    {
        public string Usuario { get; set; } = null!;
        public string? CodigoDelVehiculo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
