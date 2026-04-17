using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteIngresosAutomatico
    {
        public int CodIngreso { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public string? NumeroTitulo { get; set; }
        public int? Cantidad { get; set; }
        public float ValorTitulo { get; set; }
        public string? Concepto { get; set; }
        public DateTime? FechaPago { get; set; }
        public string UserIngreso { get; set; } = null!;
        public string? UserCobro { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? TipoDeIngreso { get; set; }
        public DateTime? FechaHoraProceso { get; set; }
    }
}
