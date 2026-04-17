using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Logtitulo
    {
        public string? Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int? CodIngreso { get; set; }
        public double? ValorTitulo { get; set; }
        public string? Descripcion { get; set; }
    }
}
