using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RaPreguntasEncuentum
    {
        public RaPreguntasEncuentum()
        {
            RaEncuestaCiudadanos = new HashSet<RaEncuestaCiudadano>();
            RaRespuestaEncuenta = new HashSet<RaRespuestaEncuentum>();
        }

        public int IdPregunta { get; set; }
        public string? Pregunta { get; set; }

        public virtual ICollection<RaEncuestaCiudadano> RaEncuestaCiudadanos { get; set; }
        public virtual ICollection<RaRespuestaEncuentum> RaRespuestaEncuenta { get; set; }
    }
}
