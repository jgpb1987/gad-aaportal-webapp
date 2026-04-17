using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RaDatosGenerale
    {
        public RaDatosGenerale()
        {
            RaEncuestaCiudadanos = new HashSet<RaEncuestaCiudadano>();
        }

        public string Cedula { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? DireccionEst { get; set; }
        public string? Parroquia { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? TipoActividad { get; set; }

        public virtual ICollection<RaEncuestaCiudadano> RaEncuestaCiudadanos { get; set; }
    }
}
