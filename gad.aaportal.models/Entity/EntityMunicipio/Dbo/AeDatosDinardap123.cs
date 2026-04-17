using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeDatosDinardap123
    {
        public int AnioFiscal { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string SustitutivaOriginal { get; set; } = null!;
        public decimal? SubIngRgrTyc3195 { get; set; }
        public decimal? SubIngRgrTycSrd3200 { get; set; }
        public decimal? IngresosLepOli3120 { get; set; }
        public decimal? IngSyoTrabajoRde3240 { get; set; }
        public decimal? IngresosAemRie1280 { get; set; }
        public decimal? AvaluoArriendoInmuebles3030 { get; set; }
        public decimal? TotActCorriente410 { get; set; }
        public decimal? TotActivoNoCorriente812 { get; set; }
        public decimal? TotalActivo830 { get; set; }
        public decimal? TotalIngresos1440 { get; set; }
        public decimal? TotalPasivo1310 { get; set; }
        public decimal? TotPasivoCorriente1030 { get; set; }
        public decimal? TotPatrimonioNeto1330 { get; set; }
        public decimal? PerdidaEjercicio2810 { get; set; }
        public decimal? UtilidadNetaEjercicio2800 { get; set; }
        public decimal? RebajaDiscapacidad3350 { get; set; }
        public decimal? RebajaTerceraEdad3340 { get; set; }
        public string? CodigoPaquete { get; set; }
    }
}
