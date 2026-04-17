using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RutaVehiculo
    {
        public int CodigoVehiculo { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraRetorno { get; set; }
        public float? KmSalida { get; set; }
        public float? KmRetorno { get; set; }
        public float? KmRecorridos { get; set; }
        public string DescripcionRecorrido { get; set; } = null!;
        public string? Oficina { get; set; }
        public float? CombustibleSalida { get; set; }
        public float? CombustibleRetorno { get; set; }
        public float? CombustibleConsumido { get; set; }
        public string? HorasExtras50 { get; set; }
        public string? HorasExtras100 { get; set; }
        public string CodigoFacturaEntrega { get; set; } = null!;
        public string? Destino { get; set; }
        public int? Frecuencia { get; set; }

        public virtual FacturaEntrega CodigoFacturaEntregaNavigation { get; set; } = null!;
        public virtual Vehiculo CodigoVehiculoNavigation { get; set; } = null!;
    }
}
