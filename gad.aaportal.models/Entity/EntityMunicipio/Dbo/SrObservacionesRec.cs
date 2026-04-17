using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SrObservacionesRec
    {
        public int Id { get; set; }
        public int? CodigoIngresoV { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? Observaciones { get; set; }
    }
}
