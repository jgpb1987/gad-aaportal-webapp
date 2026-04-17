using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaParaRendimientosVehiculo
    {
        public string CodigoFactura { get; set; } = null!;
        public DateTime FechaFactura { get; set; }
        public float CantidadDetalleFactura { get; set; }
        public float PredioDetalleFactura { get; set; }
        public string NumeroVehiculo { get; set; } = null!;
        public string? MarcaVehiculo { get; set; }
        public string? ModeloVehiculo { get; set; }
        public int? AnioVehiculo { get; set; }
        public string? AreaTrabajoVehiculo { get; set; }
        public string? PropietarioVehiculo { get; set; }
        public string? PlacasVehiculo { get; set; }
        public string? TipoVehiculo { get; set; }
        public string? TipoCombustible { get; set; }
        public double? KmRecomendadosVehiculo { get; set; }
        public double? KmrecorridosRutas { get; set; }
    }
}
