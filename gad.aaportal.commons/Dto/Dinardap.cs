using gad.aaportal.commons.Base;

namespace gad.aaportal.commons.Dto
{
    public class Form101DtoRequest
    {
        public int AnioFiscal { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public decimal? PerdidaEjercicio3430 { get; set; }
        public decimal? TotActivoNoCorriente1077 { get; set; }
        public decimal? TotPasivosCorrientes1340 { get; set; }
        public decimal? TotalActivo1080 { get; set; }
        public decimal? TotalActivoCorriente470 { get; set; }
        public decimal? TotalIngresos1930 { get; set; }
        public decimal? TotalPasivos1620 { get; set; }
        public decimal? TotalPatrimonioNeto1780 { get; set; }
        public decimal? TotasCostosGastos3380 { get; set; }
        public decimal? UtilidadEjercicio3420 { get; set; }
        public decimal? TotalPasivosLargoPlazo1590 { get; set; }
        public decimal? ProNoctePasCtgComNeg1577 { get; set; }
    }

    public class Form102DtoRequest
    {
        public int AnioFiscal { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string? SustitutivaOriginal { get; set; }

        public decimal? AvaluoArriendoInmuebles3030 { get; set; }
        public decimal? AvaArriendoOtrosAct3070 { get; set; }
        public decimal? DepreciacionAcumulada530 { get; set; }
        public decimal? EcoSoftware480 { get; set; }
        public decimal? IngresosLepOli3120 { get; set; }
        public decimal? InmueblesExceptoTerrenos420 { get; set; }
        public decimal? MaqEquInstalaciones450 { get; set; }
        public decimal? MueblesEnseres440 { get; set; }
        public decimal? PerdidaEjercicio2810 { get; set; }
        public decimal? RebajaDiscapacidad3350 { get; set; }
        public decimal? RebajaTerceraEdad3340 { get; set; }
        public decimal? SubIngRgrTyc3195 { get; set; }
        public decimal? SubIngRgrTycSrd3200 { get; set; }
        public decimal? Terrenos540 { get; set; }
        public decimal? TotActCorriente410 { get; set; }
        public decimal? TotActivoNoCorriente812 { get; set; }
        public decimal? TotPasivoCorriente1030 { get; set; }
        public decimal? TotPatrimonioNeto1330 { get; set; }
        public decimal? TotalActivo830 { get; set; }
        public decimal? TotalActivoFijo560 { get; set; }
        public decimal? TotalCostosGastos2760 { get; set; }
        public decimal? TotalIngresos1440 { get; set; }
        public decimal? TotalPasivo1310 { get; set; }
        public decimal? UtilidadNetaEjercicio2800 { get; set; }
        public decimal? VehiculosEqtEqc490 { get; set; }
        public decimal? VneGrvTce1360 { get; set; }
        public decimal? IngresosAemRie1280 { get; set; }
        public decimal? IngSyoTrabajoRde3240 { get; set; }
        public decimal? CdoCliRelExterior190 { get; set; }
    }

    public class Form101SaveDtoResult : BaseResult
    {
        public bool Result { get; set; } = false;
    }

    public class Form102SaveDtoResult : BaseResult
    {
        public bool Result { get; set; } = false;
    }
}
