using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Titulo1
    {
        public int? CodCreacionTitulo { get; set; }
        public int? CodDescipcion { get; set; }
        public int? Orden { get; set; }
        public string CodTitulo { get; set; } = null!;
        public string? DescripcionTitulo { get; set; }
        public string? DescripcionDescripcion { get; set; }
    }
}
