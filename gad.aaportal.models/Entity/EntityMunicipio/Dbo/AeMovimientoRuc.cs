using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeMovimientoRuc
    {
        public int IdMovimiento { get; set; }
        public DateTime? Fecha { get; set; }
        /// <summary>
        /// &apos;A&apos; =  Estado Activo, &apos;S&apos; = Suspendido, &apos;I&apos; = Proceso de disolución
        /// </summary>
        public string? Estado { get; set; }
        public string? Observacion { get; set; }
        public string? Ruc { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? Reactivacion { get; set; }
        public DateTime? FechaIngreso { get; set; }

        public virtual AeEstadoRuc? EstadoNavigation { get; set; }
        public virtual AeIdentificacionContribuyente? RucNavigation { get; set; }
    }
}
