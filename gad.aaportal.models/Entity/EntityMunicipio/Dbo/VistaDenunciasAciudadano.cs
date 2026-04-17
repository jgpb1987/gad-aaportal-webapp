using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDenunciasAciudadano
    {
        public int IdDenunciasAciudadanos { get; set; }
        public string? CedulaCiudadanoDenunciante { get; set; }
        public string? NombreDenunciante { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? DireccionDenunciante { get; set; }
        public string? TelefonoDenunciante { get; set; }
        public string? CedulaCiudadanoDenunciado { get; set; }
        public string? NombreDenunciado { get; set; }
        public string? DireccionDenunciado { get; set; }
        public string? TelefonoDenunciado { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string? Descripcion { get; set; }
        public string? Denominacion { get; set; }
        public string? CalidadAmbientalItem { get; set; }
        public string? CalidadAmbiental { get; set; }
        public string ClaveCatastral { get; set; } = null!;
        public string? InformacionCiudadano { get; set; }
        public int? IdEstadoProceso { get; set; }
        public string? Usuario { get; set; }
        public string? EstadoDescripcion { get; set; }
        public string? CarpetaUbicacionImagen { get; set; }
        public int? NroDenuncia { get; set; }
    }
}
