using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelTiposComprobante
    {
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal InicioSecuencia { get; set; }
    }
}
