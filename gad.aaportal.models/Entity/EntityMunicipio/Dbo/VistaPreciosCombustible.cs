using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaPreciosCombustible
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public double? Precio { get; set; }
        public double? PrecioConIva { get; set; }
        public int IdProductoPrecio { get; set; }
    }
}
