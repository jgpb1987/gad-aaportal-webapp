using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SrVendiblesTesorerium
    {
        public SrVendiblesTesorerium()
        {
            SrDatosIngresoVendibles = new HashSet<SrDatosIngresoVendible>();
        }

        public int IdVendibleTesoreria { get; set; }
        public int? CodigoVendible { get; set; }
        public int? VendibleDesde { get; set; }
        public int? VendibleHasta { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public double? ValorVendible { get; set; }
        public int? TotalVendible { get; set; }
        public string? UsuarioIngreso { get; set; }
        public string? NumeroTramite { get; set; }
        public string? UsuarioAsignado { get; set; }
        public string? Comentario { get; set; }
        public double? ValorTotal { get; set; }
        public string? Estado { get; set; }

        public virtual SrVendible? CodigoVendibleNavigation { get; set; }
        public virtual ICollection<SrDatosIngresoVendible> SrDatosIngresoVendibles { get; set; }
    }
}
