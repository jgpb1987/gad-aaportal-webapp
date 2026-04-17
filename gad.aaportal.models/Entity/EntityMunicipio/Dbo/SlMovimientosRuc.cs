using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlMovimientosRuc
    {
        public int Id { get; set; }
        public string? Ruc { get; set; }
        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Usuario { get; set; }
        public string? Observaciones { get; set; }
    }
}
