using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeLocal
    {
        public int IdLocal { get; set; }
        public int? IdActividad { get; set; }
        public string? LocalPropio { get; set; }
        public string? LocalPrincipal { get; set; }
        public int? NroEstablecimiento { get; set; }
        public string? Nombre { get; set; }
        public string? EmailLocal { get; set; }
        public string? TelefonoLocal { get; set; }
        public string? ClaveCatastral { get; set; }
        public DateTime? FechaAperturaLocal { get; set; }
        public string? Usuario { get; set; }
        /// <summary>
        /// A=Activo
        /// E=Eliminado
        /// </summary>
        public string? Estado { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
        public virtual AeActividadEconomica? IdActividadNavigation { get; set; }
    }
}
