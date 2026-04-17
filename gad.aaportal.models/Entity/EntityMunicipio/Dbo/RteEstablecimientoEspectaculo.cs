using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteEstablecimientoEspectaculo
    {
        public int CodigoEstablecimiento { get; set; }
        public string? NombreEstablecimiento { get; set; }
        public string? Direccionestablecimiento { get; set; }
        public int? CapacidadEstablecimiento { get; set; }
        public string? Propietarioestablecimento { get; set; }
        public string? Estadoestablecimiento { get; set; }
        public string? Usuario { get; set; }
    }
}
