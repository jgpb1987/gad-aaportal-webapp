using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Iva
    {
        public string? DescripcionTitulo { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public string? Nombre { get; set; }
        public double ValorTitulo { get; set; }
        public double? Iva1 { get; set; }
        public int CodIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? EstadoIngreso { get; set; }
    }
}
