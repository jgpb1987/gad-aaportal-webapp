using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SrVendible
    {
        public SrVendible()
        {
            SrDatosIngresoVendibles = new HashSet<SrDatosIngresoVendible>();
            SrVendiblesTesoreria = new HashSet<SrVendiblesTesorerium>();
        }

        public int Codigo { get; set; }
        public string CodVendible { get; set; } = null!;
        public string? Descripcion { get; set; }
        public double? Valor { get; set; }
        /// <summary>
        /// &apos;A&apos; = Activo
        /// &apos;I&apos; = Inactivo
        /// </summary>
        public string? Estado { get; set; }
        public string? UsuarioIngreso { get; set; }
        public string? IdOrden { get; set; }

        public virtual ICollection<SrDatosIngresoVendible> SrDatosIngresoVendibles { get; set; }
        public virtual ICollection<SrVendiblesTesorerium> SrVendiblesTesoreria { get; set; }
    }
}
