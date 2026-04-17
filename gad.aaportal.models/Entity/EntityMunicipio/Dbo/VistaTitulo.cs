using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTitulo
    {
        public string CodClienteIngreso { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public string? Anio { get; set; }
        public int CodIngreso { get; set; }
        public string? Comentario { get; set; }
        public double ValorTitulo { get; set; }
        public double? Valor { get; set; }
        public string? ClaveCatastral { get; set; }
    }
}
