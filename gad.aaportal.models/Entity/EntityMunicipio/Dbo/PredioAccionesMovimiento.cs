using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PredioAccionesMovimiento
    {
        public int Id { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Cedula { get; set; }
        public int? CodigoIngresoRentas { get; set; }
        public string? UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
