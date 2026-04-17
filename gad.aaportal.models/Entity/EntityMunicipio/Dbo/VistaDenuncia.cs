using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDenuncia
    {
        public int Id { get; set; }
        public string? CedulaCiudadanoDenunciante { get; set; }
        public string? NombreDenunciante { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? DireccionDenunciante { get; set; }
        public string? TelefonoDenunciante { get; set; }
        public string? CedulaORuc { get; set; }
        public string? NombreORazonSocial { get; set; }
        public string? DireccionDenuncia { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Receptor { get; set; }
        public string? TipoDenuncia { get; set; }
        public string? DescripcionTipo { get; set; }
        public int? IdEstadoProceso { get; set; }
        public string? EstadoDescripcion { get; set; }
        public string? Imagen { get; set; }
        public int? NroDenuncia { get; set; }
        public int? IdCalidadAmbientalItem { get; set; }
    }
}
