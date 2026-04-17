using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaGeoPortal
    {
        public string? CodCatastralPredio { get; set; }
        public string CedulaCiudadano { get; set; } = null!;
        public string? ApellidosCiudadano { get; set; }
        public string? NombresCiudadano { get; set; }
        public string? Nombrecompleto { get; set; }
    }
}
