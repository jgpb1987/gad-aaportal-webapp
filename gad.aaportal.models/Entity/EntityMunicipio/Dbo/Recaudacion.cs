using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Recaudacion
    {
        public string? DescripcionTitulo { get; set; }
        public string? DescripcionDescripcion { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public double? Valor { get; set; }
    }
}
