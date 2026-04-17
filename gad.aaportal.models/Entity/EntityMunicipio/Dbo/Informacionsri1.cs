using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Informacionsri1
    {
        public string? NúmeroRuc { get; set; }
        public string? RazónSocial { get; set; }
        public string? AñoFiscal { get; set; }
        public double? TotalActivoCorriente { get; set; }
        public double? ActivosBiológicos { get; set; }
        public double? PropiedadesDeInversión { get; set; }
        public double? TotalActivosFijos { get; set; }
        public double? TotalActivos { get; set; }
        public double? TotPasivosCorrientes { get; set; }
        public double? TotalPasivos { get; set; }
        public double? Patrimonio { get; set; }
        public string? Tipo { get; set; }
    }
}
