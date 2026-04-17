using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StCertificacione
    {
        public int IdCertificaciones { get; set; }
        public DateTime? Fecha { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Cibeneficiario { get; set; }
        public string? Cipropietario { get; set; }
        public int? NumeroDeTramite { get; set; }
        public double? AreaTotalTerreno { get; set; }
        public double? ValorPredio { get; set; }
        public string? Tipo { get; set; }
        public string? TipoCertificado { get; set; }
        public string? Observacion { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorConstruccion { get; set; }
        public double? AreaConstruccion { get; set; }
        public double? ValorMetroCuadrado { get; set; }
        public string? DescripcionValidoPara { get; set; }

        public virtual StTramite? NumeroDeTramiteNavigation { get; set; }
        public virtual StTipoCertificacione? TipoCertificadoNavigation { get; set; }
    }
}
