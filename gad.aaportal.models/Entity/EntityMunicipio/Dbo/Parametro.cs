using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Parametro
    {
        public byte CodParametros { get; set; }
        public string DescripcionParametros { get; set; } = null!;
        public float ValorParametros { get; set; }
        public DateTime? FechaSistema { get; set; }
    }
}
