using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Proveedor
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }
    }
}
