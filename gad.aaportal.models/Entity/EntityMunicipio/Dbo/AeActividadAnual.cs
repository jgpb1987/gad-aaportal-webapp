using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadAnual
    {
        public AeActividadAnual()
        {
            AeActivosTotalesCantones = new HashSet<AeActivosTotalesCantone>();
            AeActivosTotalesPendientes = new HashSet<AeActivosTotalesPendiente>();
        }

        public int IdActividadAnual { get; set; }
        public string? Ruc { get; set; }
        public string? NroDeclaracion { get; set; }
        public double? IngresoTotales { get; set; }
        public double? TotalActivos { get; set; }
        public double? TotalPasivos { get; set; }
        public double? Patrimonio { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? AnioPatente { get; set; }
        public double? BaseImponiblePatente { get; set; }
        public double? Exento { get; set; }
        public double? TarifaPatente { get; set; }
        public double? MultaPatente { get; set; }
        public int? PorcentajeDescuentoTercera { get; set; }
        public string? UsuarioIngreso { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public double? Utilidad { get; set; }
        public double? TarifaPatenteFija { get; set; }
        public int? PorDescuentoPerdidas { get; set; }
        public double? ContingenciaPasivos { get; set; }
        public double? BaseImponibleIat { get; set; }
        public double? ImpuestoIat { get; set; }
        public double? MultaIat { get; set; }
        public int? CodigoIngresoPatente { get; set; }
        public int? CodigoIngresoIat { get; set; }
        public double? MontoPerdida { get; set; }
        public double? PorcentajeCalculoIat { get; set; }
        public double? AreaArriendo { get; set; }
        public string? ActividadCod { get; set; }
        public string? Contabilidad { get; set; }
        public string? Rise { get; set; }
        public int? Exoneracion { get; set; }
        public string? Sustitutiva { get; set; }
        public int? CodigoMulta { get; set; }
        public string? ObservacionMulta { get; set; }
        public double? PagoSri { get; set; }
        public int? PorcentajeTeiat { get; set; }
        public double? DescuentoTeiat { get; set; }
        public double? ValorEmitidoIat { get; set; }
        public double? DescuentoTepma { get; set; }

        public virtual AeIdentificacionContribuyente? RucNavigation { get; set; }
        public virtual ICollection<AeActivosTotalesCantone> AeActivosTotalesCantones { get; set; }
        public virtual ICollection<AeActivosTotalesPendiente> AeActivosTotalesPendientes { get; set; }
    }
}
