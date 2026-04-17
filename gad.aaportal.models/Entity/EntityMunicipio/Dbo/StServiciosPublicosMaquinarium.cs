using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StServiciosPublicosMaquinarium
    {
        public int NumeroDeTramite { get; set; }
        public int IdMaquinaria { get; set; }
        public int TiempoAlquiler { get; set; }
        public int? NumeroViajes { get; set; }
    }
}
