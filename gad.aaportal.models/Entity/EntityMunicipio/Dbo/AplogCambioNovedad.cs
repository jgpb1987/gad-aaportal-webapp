using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AplogCambioNovedad
    {
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
        public int? Sector { get; set; }
        public int? Cuenta { get; set; }
        public string? Anio { get; set; }
        public string? Mes { get; set; }
        public string? NovedadAnterior { get; set; }
        public string? NovedadActual { get; set; }
        public string? RazonModifica { get; set; }
    }
}
