using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiDatosCompra
    {
        public SiDatosCompra()
        {
            SiCalculoImpuestos = new HashSet<SiCalculoImpuesto>();
        }

        public int IdCompra { get; set; }
        public DateTime? FechaVenta { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public string? Vendedor { get; set; }
        public string? Comprador { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? ValorEscritura { get; set; }
        public double? ValorVenta { get; set; }
        public double? AdecuacionesInmueble { get; set; }
        public double? ValorContribucionEspecialMej { get; set; }
        public int? NroVenta { get; set; }
        public string? UsuarioIngreso { get; set; }
        public int? IdDominio { get; set; }
        public int? NroTramite { get; set; }
        public int? NroAvisoAlcabala { get; set; }
        public double? PorcentajeTransferenciaEscritura { get; set; }
        public double? ValorEscrituraCalculo { get; set; }
        public string? TipoPorcentaje { get; set; }
        public string? Observaciones { get; set; }
        public double? Construcciones { get; set; }
        public string? Bies { get; set; }
        public string? ObservacionCert { get; set; }

        public virtual ICollection<SiCalculoImpuesto> SiCalculoImpuestos { get; set; }
    }
}
