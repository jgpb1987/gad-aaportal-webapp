using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaValoresPorRecaudar2015
    {
        public int CodIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public double? Valor { get; set; }
        public string? Nombre { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Direccion { get; set; }
        public string? Comentario { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
    }
}
