using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaDenunciasActividadesEconomica
    {
        public int IdDenunciasActividadEconomica { get; set; }
        public string? CedulaCiudadanoDenunciante { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? DireccionDenunciante { get; set; }
        public string? TelefonoDenunciante { get; set; }
        public string? RucActividadEconomica { get; set; }
        public string? DireccionActividad { get; set; }
        public string? TelefonoActividad { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string? Descripcion { get; set; }
        public string? CedulaRepresentanteLegal { get; set; }
        public string? RazonSocial { get; set; }
        public string? NroLocal { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Usuario { get; set; }
        public int? IdCalidadAmbientalItem { get; set; }
        public int? IdEstadoProceso { get; set; }
        public int? NroDenuncia { get; set; }

        public virtual Ciudadano? CedulaCiudadanoDenuncianteNavigation { get; set; }
        public virtual SaCalidadAmbientalItem? IdCalidadAmbientalItemNavigation { get; set; }
        public virtual SaEstadoProceso? IdEstadoProcesoNavigation { get; set; }
    }
}
