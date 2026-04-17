using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StAlquilerCanchaFutbol
    {
        public int NumeroDeTramite { get; set; }
        public string Valor { get; set; } = null!;
        public string NumeroDePartidos { get; set; } = null!;
        public string HoraTurno { get; set; } = null!;
        public string FechaUsoCancha { get; set; } = null!;
        public string Ciudadano { get; set; } = null!;

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
