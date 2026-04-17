using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StDatosVia
    {
        public int IdDatosVias { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? NombreCalle { get; set; }
        public string? AnchoMetros { get; set; }
        public string? LineaDeFabrica { get; set; }
        public string? LineaDeNivel { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
