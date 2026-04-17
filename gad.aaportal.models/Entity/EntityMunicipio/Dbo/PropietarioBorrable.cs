using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PropietarioBorrable
    {
        public string InsRuc { get; set; } = null!;
        public string CiuCedula { get; set; } = null!;
        public string? ProCiudadDomicilio { get; set; }
        public string? ProDireccionDomicilio { get; set; }
        public string? ProTelefono { get; set; }
        public string? ProEmail { get; set; }
    }
}
