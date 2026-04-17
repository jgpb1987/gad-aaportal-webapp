using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioAccionario
    {
        public int IdAccDer { get; set; }
        public string Cedula { get; set; } = null!;
        public double? Porcentaje { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? UsuarioIngreso { get; set; }

        public virtual Ciudadano CedulaNavigation { get; set; } = null!;
        public virtual PredioAccionesDerecho IdAccDerNavigation { get; set; } = null!;
    }
}
