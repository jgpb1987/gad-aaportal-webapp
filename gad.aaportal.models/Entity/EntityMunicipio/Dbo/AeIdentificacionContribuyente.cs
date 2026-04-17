using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeIdentificacionContribuyente
    {
        public AeIdentificacionContribuyente()
        {
            //AeActividadAnuals = new HashSet<AeActividadAnual>();
            //AeActividadEconomicas = new HashSet<AeActividadEconomica>();
            //AeDeterminacionPresuntivas = new HashSet<AeDeterminacionPresuntiva>();
            //AeMovimientoRucs = new HashSet<AeMovimientoRuc>();
            //AeNotificaciones = new HashSet<AeNotificacione>();
        }

        public string Ruc { get; set; } = null!;
        public int? IdPersoneria { get; set; }
        public string CiPropietarioRepresentante { get; set; } = null!;
        public string? RazonSocial { get; set; }
        /// <summary>
        /// &apos;S&apos; Si esta obligado a llevar contabilidad
        /// &apos;N&apos; si no esta obligado a llevar contabilidad
        /// </summary>
        public string? Contabilidad { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public double? CapitalSocial { get; set; }
        public double? PatrimonioInicial { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? EstadoRuc { get; set; }
        public string? Rise { get; set; }
        public int? Exoneracion { get; set; }
        public string? Observaciones { get; set; }

        //public virtual Ciudadano CiPropietarioRepresentanteNavigation { get; set; } = null!;
        //public virtual AeEstadoRuc? EstadoRucNavigation { get; set; }
        //public virtual AePersonerium? IdPersoneriaNavigation { get; set; }
        //public virtual ICollection<AeActividadAnual> AeActividadAnuals { get; set; }
        //public virtual ICollection<AeActividadEconomica> AeActividadEconomicas { get; set; }
        //public virtual ICollection<AeDeterminacionPresuntiva> AeDeterminacionPresuntivas { get; set; }
        //public virtual ICollection<AeMovimientoRuc> AeMovimientoRucs { get; set; }
        //public virtual ICollection<AeNotificacione> AeNotificaciones { get; set; }
    }
}
