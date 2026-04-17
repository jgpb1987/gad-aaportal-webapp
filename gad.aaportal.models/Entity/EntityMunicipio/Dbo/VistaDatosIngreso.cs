using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDatosIngreso
    {
        public int CodIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public string? EstadoIngreso { get; set; }
        public string? Nombre { get; set; }
        public double ValorTitulo { get; set; }
        public double? Resultadosuma { get; set; }
    }
}
