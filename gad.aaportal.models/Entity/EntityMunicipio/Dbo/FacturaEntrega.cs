using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class FacturaEntrega
    {
        public FacturaEntrega()
        {
            RutaVehiculos = new HashSet<RutaVehiculo>();
        }

        public string Codigo { get; set; } = null!;
        public string CodigoProveedor { get; set; } = null!;
        public int CodigoVehiculo { get; set; }
        public DateTime Fecha { get; set; }
        public float Valor { get; set; }
        public float? KmVehiculo { get; set; }
        public float? KmGasolinera { get; set; }
        public float? KmDiferencia { get; set; }
        public string? Descripcion { get; set; }
        public bool? Tipo { get; set; }

        public virtual ICollection<RutaVehiculo> RutaVehiculos { get; set; }
    }
}
