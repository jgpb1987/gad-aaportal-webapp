using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class InterNoCobradorPorRemicion
    {
        public double? InteresQueDebioPagar { get; set; }
        public double? InteresQuePago { get; set; }
        public double? Diferencia { get; set; }
        public double ValorTitulo { get; set; }
        public string Cedula { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaVencInteres { get; set; }
        public DateTime? FechaPago { get; set; }
        public int CodIngreso { get; set; }
        public string CodTituloDatos { get; set; } = null!;
    }
}
