using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RaEncuestaCiudadano
    {
        public int IdEncuesta { get; set; }
        public int? IdPregunta { get; set; }
        public string? Respuesta { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual RaDatosGenerale? CedulaNavigation { get; set; }
        public virtual RaPreguntasEncuentum? IdPreguntaNavigation { get; set; }
    }
}
