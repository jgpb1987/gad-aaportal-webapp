using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaDenunciasAciudadano
    {
        public int IdDenunciasAciudadanos { get; set; }
        public string? CedulaCiudadanoDenunciante { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? DireccionDenunciante { get; set; }
        public string? TelefonoDenunciante { get; set; }
        public string? CedulaCiudadanoDenunciado { get; set; }
        public string? DireccionDenunciado { get; set; }
        public string? TelefonoDenunciado { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string? Descripcion { get; set; }
        public string? Usuario { get; set; }
        public int? IdCalidadAmbientalItem { get; set; }
        public int? IdEstadoProceso { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? InformacionCiudadano { get; set; }
        public string? CarpetaUbicacionImagen { get; set; }
        public int? NroDenuncia { get; set; }

        public virtual Ciudadano? CedulaCiudadanoDenunciadoNavigation { get; set; }
        public virtual Ciudadano? CedulaCiudadanoDenuncianteNavigation { get; set; }
        public virtual SaCalidadAmbientalItem? IdCalidadAmbientalItemNavigation { get; set; }
        public virtual SaEstadoProceso? IdEstadoProcesoNavigation { get; set; }
    }
}
