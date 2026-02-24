using gad.aaportal.commons.Base;

namespace gad.aaportal.commons.Dto
{
    public class Form101Dto
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

    public class ListForm101
    {
        public List<Form101Dto> Form101s { get; set; } = new();
    }

    public class Form102Dto
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

    public class ListForm102
    {
        public List<Form102Dto> Form102s { get; set; } = new List<Form102Dto>();
    }

    public class Paquete7728
    {
        public string NumeroRuc { get; set; } = string.Empty;
        public int NumeroEstablecimiento { get; set; }
        public string CodigoActividad { get; set; } = string.Empty!;
        public string? ActividadEconomica { get; set; }
    }

    public class Lista7728
    {
        public List<Paquete7728> paquete7728s { get; set; } = new List<Paquete7728>();
    }

    public class Paquete7730
    {
        public string? ClaseContribuyente { get; set; }
        public string? CodigoClaseContribuyente { get; set; }
        public string? CodigoEstadoContribuyente { get; set; }
        public string? EstadoContribuyente { get; set; }
        public string? EstadoPersona { get; set; }
        public string? EstadoSociedad { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public DateTime? FechaReinicioActividades { get; set; }
        public DateTime? FechaSuspensionDefinitiva { get; set; }
        public string? Obligado { get; set; }
        public string? PersonaSociedad { get; set; }
        public DateTime? FechaInscripcionRuc { get; set; }
        public DateTime? FechaConstitucion { get; set; }
        public string? NumeroRegistroMercantil { get; set; }
        public DateTime? FechaFusion { get; set; }
        public DateTime? FechaEscision { get; set; }
        public string? CapitalSuscrito { get; set; }
        public DateTime? FechaNombramiento { get; set; }
        public string? CategoriaRise { get; set; }
        public string? ComercioExterior { get; set; }
        public string? NumRucSociedadAdscrita { get; set; }
        public string? NumRucSociedadEscisionada { get; set; }
        public string? NumeroRucFusionado { get; set; }
        public string? NumeroPatronal { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? OrigenSociedad { get; set; }
        public string? GerenteGeneral { get; set; }
        public DateTime? FechaNombramientoGerente { get; set; }
        public string? NumeroRegistroColegioGremio { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Lista7730
    {
        public List<Paquete7730> paquete7730s { get; set; } = new List<Paquete7730>();
    }

    public class Paquete7731
    {
        public string NumeroRuc { get; set; }
        public string NumeroEstablecimiento { get; set; }
        public string Calle { get; set; }
        public string EstadoEstablecimiento { get; set; }
        public string Interseccion { get; set; }
        public string NombreFantasiaComercial { get; set; }
        public string TipoEstablecimiento { get; set; }
        public string ReferenciaUbicacion { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public DateTime? FechaReinicioActividades { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string VerificacionUbicacion { get; set; }
        public string UbicacionGeografica { get; set; }
        public string Barrio { get; set; }
        public string Ciudadela { get; set; }
        public string Conjunto { get; set; }
        public string Bloque { get; set; }
        public string NombreEdificio { get; set; }
        public string NumeroOficina { get; set; }
        public string Manzana { get; set; }
        public string Supermanzana { get; set; }
        public string Kilometro { get; set; }
        public string Carretero { get; set; }
        public string Camino { get; set; }
        public string NumeroPiso { get; set; }
        public string ResultadoVerificacion { get; set; }
        public string DireccionPresunta { get; set; }
        public DateTime FechaGrabado { get; set; }
    }

    public class Lista7731
    {
        public List<Paquete7731> paquete7731s { get; set; } = new List<Paquete7731>();
    }

    public class Paquete7732
    {
        public string NumeroRuc { get; set; }
        public string MarcaListaBlanca { get; set; }
        public DateTime FechaGrabado { get; set; }
    }

    public class Lista7732
    {
        public List<Paquete7732> paquete7732s { get; set; } = new List<Paquete7732>();
    }

    public class Form101SaveDtoResult : BaseResult
    {
        public bool Result { get; set; } = false;
    }

    public class Form102SaveDtoResult : BaseResult
    {
        public bool Result { get; set; } = false;
    }

    public class ConsumoDinardapResult : BaseResult
    {
        public bool SaveForm101 { get; set; } = false;
        public bool SaveForm102 { get; set; } = false;
        public bool Save7728 { get; set; } = false;
        public bool Save7730 { get; set; } = false;
        public bool Save7731 { get; set; } = false;
        public bool Save7732 { get; set; } = false;
    }

    public class PaqueteDinardapRequest
    {
        public string identificacion { get; set; }
        public string paquete { get; set; }
    }
}
