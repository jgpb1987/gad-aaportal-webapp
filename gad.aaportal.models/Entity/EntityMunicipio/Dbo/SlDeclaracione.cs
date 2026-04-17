using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlDeclaracione
    {
        public int? AnioDeclaracion { get; set; }
        public string? Ruc { get; set; }
        public string? Nombres { get; set; }
        public string? Nombre { get; set; }
        public double? Tasa { get; set; }
        public double? Multa { get; set; }
        public double? ValorTitulo { get; set; }
        public int? CodIngreso { get; set; }
        public string Estado { get; set; } = null!;
        public string? EstadoIngreso { get; set; }
        public string? Categoria { get; set; }
    }
}
