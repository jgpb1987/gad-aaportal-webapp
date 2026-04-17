using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalAnual
    {
        public LocalAnual()
        {
            LocalAnualPagos = new HashSet<LocalAnualPago>();
        }

        public string Ruc { get; set; } = null!;
        public string? NroLocal { get; set; }
        public int AutoNumerico { get; set; }
        public DateTime? FechaEmicion { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public double? NumeroDeclaracionIr { get; set; }
        public double? IngresosTotales { get; set; }
        public double? AreaAe { get; set; }
        public double? ValorAreaEnUso { get; set; }
        public double? ExonerarArtesanoCalificado { get; set; }
        public double? SanciónArtesanoCalificado { get; set; }
        public string? FormaPagoPatente { get; set; }
        public int? CodIngTesoPatente { get; set; }
        public string? ComentarioPatente { get; set; }
        public double? BipatenteMensual { get; set; }
        public DateTime? FechaVencimientoPatente { get; set; }
        public double? MultaPatente { get; set; }
        public double? IpatenteMensualAnualizada { get; set; }
        public double? TotalPatente { get; set; }
        public double? TotalActivos { get; set; }
        public double? PasivoCorriente { get; set; }
        public double? Contingencias { get; set; }
        public double? TotalActivoPresuntivo { get; set; }
        public double? PasivoCorrientePresuntivo { get; set; }
        public double? ContingenciasPresuntivo { get; set; }
        public DateTime? FechaVencimientoIat { get; set; }
        public string? FormaPagoIat { get; set; }
        public DateTime? FechaTransferenciaIat { get; set; }
        public string? NumTransferenciaIat { get; set; }
        public int? CodIngTesoIat { get; set; }
        public string? ComentarioIat { get; set; }
        public double? MultaIat { get; set; }
        public double? BiactivosTotales { get; set; }
        public double? IactivosTotales { get; set; }
        public double? TotalIat { get; set; }
        public double? Iturismo { get; set; }
        public string? IdUsuario { get; set; }
        public double? TazaDeInteresPatente { get; set; }
        public double? InteresPatente { get; set; }
        public double? TotalPatenteTotal { get; set; }
        public double? CapitalOperativo { get; set; }
        public double? Patrimonio { get; set; }
        public double? InteresIat { get; set; }
        public string? Justificativos { get; set; }

        public virtual Local? Local { get; set; }
        public virtual ICollection<LocalAnualPago> LocalAnualPagos { get; set; }
    }
}
