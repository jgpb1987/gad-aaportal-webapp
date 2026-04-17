using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SwAccesoCiudadano
    {
        public string UsuarioCiudadano { get; set; } = null!;
        public byte[]? Clave { get; set; }
    }
}
