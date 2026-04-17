using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SrDatosIngresoVendible
    {
        public int IdIngresoVendible { get; set; }
        public int? CodVendibles { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? UsuarioIngreso { get; set; }
        /// <summary>
        /// &apos;A&apos; = Asignado
        /// &apos;E&apos; = Elimina de una caja y crea nuevos registros
        /// &apos;B&apos; = Baja
        /// &apos;R&apos; = Anulado
        /// </summary>
        public string? EstadoIngreso { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string? UsuarioAsignado { get; set; }
        public string? UsuarioCobro { get; set; }
        public DateTime? FechaPago { get; set; }
        public double? Valor { get; set; }
        public string? UsuarioAsigno { get; set; }
        public int? NroVendible { get; set; }
        public int? CodAsigTesoreria { get; set; }
        public string? CodUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? IdVenta { get; set; }

        public virtual SrVendiblesTesorerium? CodAsigTesoreriaNavigation { get; set; }
        public virtual SrVendible? CodVendiblesNavigation { get; set; }
    }
}
