using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelImpuesto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
