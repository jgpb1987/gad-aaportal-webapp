using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DatosIngresoVendible
    {
        public int CodIngreso { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public int? NumeroTitulo { get; set; }
        public double ValorTitulo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaPago { get; set; }
        public string UserIngreso { get; set; } = null!;
        public string? UserCobro { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? TipoDeIngreso { get; set; }
    }
}
