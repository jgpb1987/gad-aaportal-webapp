using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ReporteTitulosEliminadosTerceraEdad
    {
        public int CodIngreso { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public string CodTituloDatos { get; set; } = null!;
        public int? NumeroTitulo { get; set; }
        public double ValorTitulo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaVencInteres { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? NombreEsp { get; set; }
        public string? Comentario { get; set; }
        public string? Direccion { get; set; }
        public string UserIngreso { get; set; } = null!;
        public string? UserCobro { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? AvaluoComercial { get; set; }
        public double? AvaluoCatastral { get; set; }
        public double? BaseImponible { get; set; }
        public string? EstadoIngreso { get; set; }
        public string? TipoDeIngreso { get; set; }
        public double? Descuentos { get; set; }
        public double? Recargo { get; set; }
        public double? Intereses { get; set; }
        public string? NumTramite { get; set; }
        public string? CodAdoquinado { get; set; }
        public int? CuotaDel { get; set; }
        public string? Nombre { get; set; }
        public double? RecargoReg { get; set; }
        public int? Notificacion { get; set; }
        public int? Citacion { get; set; }
        public string? Comentario1 { get; set; }
        public string? Recaudador { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string? ClaveCatastralAux { get; set; }
        public string? DireccionAux { get; set; }
        public string? Comentario2 { get; set; }
        public int? IndicadorReconexion { get; set; }
        public int? IdObraPredio { get; set; }
        public string? FormaDePago { get; set; }
        public string? NumeroFactura { get; set; }
        public string? TipoEmision { get; set; }
        public string? ClaveAcceso { get; set; }
        public string? NumeroAutorizacion { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public bool? ConsumidorFinal { get; set; }
        public DateTime? HoraDePago { get; set; }
        public string? EstadoNotaCredito { get; set; }
        public double? CostasJudiciales { get; set; }
    }
}
