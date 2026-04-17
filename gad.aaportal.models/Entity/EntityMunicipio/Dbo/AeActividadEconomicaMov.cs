using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadEconomicaMov
    {
        public int IdActividad { get; set; }
        public string? Ruc { get; set; }
        public int? CodigoAct { get; set; }
        public string? NroCalificacionArtesanal { get; set; }
        public DateTime? FechaCalificacionArtesanal { get; set; }
        public DateTime? FechaCaducidadCalificacionArtesanal { get; set; }
        public string? Activo { get; set; }
        public string? Iva { get; set; }
        public string? Observacion { get; set; }
        public int? IdDeclaracionAnual { get; set; }
        public int? IdLocal { get; set; }
        public string? LocalPropio { get; set; }
        public string? LocalPrincipal { get; set; }
        public int? NroEstablecimiento { get; set; }
        public string? Nombre { get; set; }
        public string? EmailLocal { get; set; }
        public string? TelefonoLocal { get; set; }
        public string? ClaveCatastral { get; set; }
        public DateTime? FechaAperturaLocal { get; set; }
        public string? Usuario { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual AeActividadAnual? IdDeclaracionAnualNavigation { get; set; }
    }
}
