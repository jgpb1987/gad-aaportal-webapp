using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaInformesDesnuncia
    {
        public int IdInformeDenuncia { get; set; }
        public int? IdDenuncia { get; set; }
        public DateTime? FechaInspeccion { get; set; }
        public string? VisitaVerificacion { get; set; }
        public DateTime? FechaInforme { get; set; }
        public string? Antecedentes { get; set; }
        public string? MarcoLegal { get; set; }
        public string? Observaciones { get; set; }
        public string? Conclusiones { get; set; }
        public string? Acciones { get; set; }
        public string? EmpleadoUsuario { get; set; }
        public string? TipoDenuncia { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? NroCitacion { get; set; }
        public DateTime? FechaPlazo { get; set; }
        public string? Observacion { get; set; }
        public int? NroInforme { get; set; }

        public virtual Empleado? EmpleadoUsuarioNavigation { get; set; }
    }
}
