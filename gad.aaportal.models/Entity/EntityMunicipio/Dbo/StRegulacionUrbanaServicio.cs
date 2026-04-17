using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRegulacionUrbanaServicio
    {
        public int NumeroDeTramite { get; set; }
        public string? AguaPotable { get; set; }
        public string? Alcantarillado { get; set; }
        public string? EnergiaElectrica { get; set; }
        public string? Calzada { get; set; }
        public string? Bordillos { get; set; }
        public string? Aceras { get; set; }
        public string? Telefonos { get; set; }
        public string? Calzada1 { get; set; }
        public string? Calzada2 { get; set; }
        public string? ObservacionEpaa { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
