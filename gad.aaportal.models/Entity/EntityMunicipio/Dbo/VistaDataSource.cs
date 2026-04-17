using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDataSource
    {
        public int IdInformeDenuncia { get; set; }
        public string? TipoDenuncia { get; set; }
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
        public string? CedulaORuc { get; set; }
        public string? NombreORazonSocial { get; set; }
        public string? DireccionDenuncia { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string? TipoDenuncia1 { get; set; }
        public string? DescripcionTipo { get; set; }
        public string? DireccionImagen { get; set; }
        public string? Denominacion { get; set; }
    }
}
