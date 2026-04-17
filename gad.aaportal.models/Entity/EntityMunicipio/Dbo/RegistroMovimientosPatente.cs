using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RegistroMovimientosPatente
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string IdUsuario { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Razon { get; set; } = null!;
    }
}
