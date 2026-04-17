using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValoresNoCobradosDesglosado
    {
        public double? InteresQueDebioPagar { get; set; }
        public double? InteresQuePago { get; set; }
        public double? Diferencia { get; set; }
        public double? ValorTitulo { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Comentario { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaVencInteres { get; set; }
        public string? FechaPago { get; set; }
        public string? CodIngreso { get; set; }
        public string? CodTituloDatos { get; set; }
        public string? ClaveCatastral { get; set; }

        public virtual ValoresNoCobradosTotal? CedulaNavigation { get; set; }
    }
}
