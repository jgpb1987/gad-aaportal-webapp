using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaDenunciasActividadesEconomica
    {
        public int IdDenunciasActividadEconomica { get; set; }
        public string? CedulaCiudadanoDenunciante { get; set; }
        public string? NombreDenunciante { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? DireccionDenunciante { get; set; }
        public string? TelefonoDenunciante { get; set; }
        public string? RazonSocial { get; set; }
        public string? RucActividadEconomica { get; set; }
        public string? NroLocal { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CedulaRepresentanteLegal { get; set; }
        public string? NombreRepresentante { get; set; }
        public string? DireccionActividad { get; set; }
        public string? TelefonoActividad { get; set; }
        public string? MotivoDenuncia { get; set; }
        public string? Descripcion { get; set; }
        public string? Denominacion { get; set; }
        public string? CalidadAmbientalItem { get; set; }
        public string? CalidadAmbiental { get; set; }
        public int? IdEstadoProceso { get; set; }
        public int? NroDenuncia { get; set; }
    }
}
