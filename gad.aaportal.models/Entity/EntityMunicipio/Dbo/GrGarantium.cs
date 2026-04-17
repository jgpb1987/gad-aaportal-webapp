using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GrGarantium
    {
        public int CodigoGarantia { get; set; }
        public string? CiGaranatia { get; set; }
        public string? CodEnlaceGarantia { get; set; }
        public string? NumeroGarantia { get; set; }
        public string? DetalleGarantia { get; set; }
        public double? ValorGarantia { get; set; }
        public string? FiscalizacionGarantia { get; set; }
        public string? AseguradoraGarantia { get; set; }
        public DateTime? FechaIngresoGarantia { get; set; }
        public DateTime? FechaProvisionalGarantia { get; set; }
        public DateTime? FechaDefinitivaGarantia { get; set; }
        public string? Observaciones { get; set; }
        public string? EstadoGarantia { get; set; }
        public string? UserIngresoGarantia { get; set; }
        public string? UserActasGarantia { get; set; }
    }
}
