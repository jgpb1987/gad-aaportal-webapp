using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioComodato
    {
        public int IdComodato { get; set; }
        public string? Cedula { get; set; }
        public string? Plazo { get; set; }
        public string? NroActa { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Estado { get; set; }

        public virtual Ciudadano? CedulaNavigation { get; set; }
    }
}
