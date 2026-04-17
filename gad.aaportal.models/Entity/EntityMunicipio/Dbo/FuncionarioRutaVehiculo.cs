using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class FuncionarioRutaVehiculo
    {
        public string? CedIdentCiudadano { get; set; }
        public DateTime? HoraSalidaRutaVehiculo { get; set; }
        public int? CodigoVehiculo { get; set; }

        public virtual Ciudadano? CedIdentCiudadanoNavigation { get; set; }
        public virtual RutaVehiculo? RutaVehiculo { get; set; }
    }
}
