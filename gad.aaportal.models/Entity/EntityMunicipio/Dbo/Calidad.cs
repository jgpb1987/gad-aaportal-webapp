using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Calidad
    {
        public string Descripcion { get; set; } = null!;
        public bool? EmitePatente { get; set; }
    }
}
