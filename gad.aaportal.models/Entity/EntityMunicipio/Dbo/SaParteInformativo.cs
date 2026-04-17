using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaParteInformativo
    {
        public int IdParteInformativo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? ParteInformativo { get; set; }
        public int? NumeroCitacion { get; set; }
        public DateTime? FechaCitacion { get; set; }
        public string? CitadoA { get; set; }
        public string? Observacion { get; set; }
        public int? IdDenuncia { get; set; }
        public string? TipoDenuncia { get; set; }
        public string? EmpleadoUsuario { get; set; }
        public DateTime? FechaCreacionParte { get; set; }

        public virtual Empleado? EmpleadoUsuarioNavigation { get; set; }
    }
}
