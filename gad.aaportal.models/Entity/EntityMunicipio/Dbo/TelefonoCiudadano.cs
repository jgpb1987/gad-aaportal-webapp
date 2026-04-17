using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TelefonoCiudadano
    {
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? ClaveCatastral { get; set; }

        public virtual Ciudadano CedulaNavigation { get; set; } = null!;
    }
}
