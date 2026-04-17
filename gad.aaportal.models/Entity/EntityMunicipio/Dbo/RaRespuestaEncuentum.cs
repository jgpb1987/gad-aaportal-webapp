using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RaRespuestaEncuentum
    {
        public int IdRespuesta { get; set; }
        public string? Respuesta { get; set; }
        public int? IdPregunta { get; set; }

        public virtual RaPreguntasEncuentum? IdPreguntaNavigation { get; set; }
    }
}
