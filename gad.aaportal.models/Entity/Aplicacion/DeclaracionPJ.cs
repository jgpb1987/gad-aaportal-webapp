namespace gad.aaportal.models.Entity.Aplicacion
{
    public class DeclaracionPJ
    {
        public string RUC { get; set; }
        public int AnioFiscal { get; set; }

        public decimal TotalActivoCorriente470 { get; set; }
        public decimal TotActivoNoCorriente1077 { get; set; }
        public decimal TotalActivo1080 { get; set; }
        public decimal TotPasivosCorrientes1340 { get; set; }
        public decimal TotalPasivosLargoPlazo1590 { get; set; }
        public decimal TotalPasivosContingente { get; set; }
        public decimal TotalPasivos1620 { get; set; }
        public decimal TotalIngresos1930 { get; set; }
        public decimal TotasCostosGastos3380 { get; set; }
        public decimal UtilidadEjercicio3420 { get; set; }
        public decimal ValorUnoPorMil { get; set; }
        public decimal ValorPatente { get; set; }

        public DateTime FechaInser { get; set; }
        public DateTime? FechaUpdate { get; set; }
    }
}
