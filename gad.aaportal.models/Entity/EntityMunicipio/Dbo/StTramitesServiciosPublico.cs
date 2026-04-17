using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramitesServiciosPublico
    {
        public int NumeroDeTramite { get; set; }
        public string? NombreAdicional { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? CodCatastralPredio { get; set; }
        public string? AprobadoJefeAvaluos { get; set; }
        public string? DireccionAlquilerMaquinaria { get; set; }
        public string? DescripcionAlquilerMaquinaria { get; set; }
        public string? ValorMulta { get; set; }
        public string? ValorAlquiler { get; set; }
        public string? NumeroDeLibros { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
