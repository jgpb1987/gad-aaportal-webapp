using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadEconomica
    {
        public AeActividadEconomica()
        {
            AeLocals = new HashSet<AeLocal>();
        }

        public int IdActividad { get; set; }
        public string? Ruc { get; set; }
        public int? CodigoAct { get; set; }
        public string? NroCalificacionArtesanal { get; set; }
        public DateTime? FechaCalificacionArtesanal { get; set; }
        public DateTime? FechaCaducidadCalificacionArtesanal { get; set; }
        /// <summary>
        /// &apos;S&apos; Activa la actividad
        /// &apos;N&apos; No esta activa la actividad
        /// </summary>
        public string? Activo { get; set; }
        public string? Iva { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual AeActividad? CodigoActNavigation { get; set; }
        public virtual AeIdentificacionContribuyente? RucNavigation { get; set; }
        public virtual ICollection<AeLocal> AeLocals { get; set; }
    }
}
