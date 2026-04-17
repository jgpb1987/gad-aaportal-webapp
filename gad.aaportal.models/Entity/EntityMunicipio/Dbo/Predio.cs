using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Predio
    {
        public Predio()
        {
            AeLocals = new HashSet<AeLocal>();
            BloquesPredios = new HashSet<BloquesPredio>();
            CondicionesSolarNoEdificados = new HashSet<CondicionesSolarNoEdificado>();
            DescripcionEdificacionPredios = new HashSet<DescripcionEdificacionPredio>();
            InfraestrServiciosPredios = new HashSet<InfraestrServiciosPredio>();
            PredioAccionesDerechoes = new HashSet<PredioAccionesDerecho>();
            PredioComentarios = new HashSet<PredioComentario>();
            PredioFrentes = new HashSet<PredioFrente>();
            SmMejorasAuxes = new HashSet<SmMejorasAux>();
            ValoresPeritajes = new HashSet<ValoresPeritaje>();
        }

        public string CodCatastralPredio { get; set; } = null!;
        public DateTime? FechaIntervencionPredio { get; set; }
        public string? Coddivpol { get; set; }
        public string? CodAnteriorPredio { get; set; }
        public string? UbiCodigo { get; set; }
        public string? CallePredio { get; set; }
        public string? NumeroPredio { get; set; }
        public string? NombrePredio { get; set; }
        public string? ProRucPropietarioBorrar { get; set; }
        public string? CiuCedula { get; set; }
        public string? Yotros { get; set; }
        public string? CedulaRepresLegPredio { get; set; }
        public string? PropAnteriorPredio { get; set; }
        public decimal? AreaTotalPredio { get; set; }
        public double? AreaEscrituras { get; set; }
        public double? AreaShp { get; set; }
        public decimal? PreAreaTotalConst { get; set; }
        public decimal? FrentePrincPredio { get; set; }
        public decimal? FondoRelatPredio { get; set; }
        public decimal? PreFrenteFondo { get; set; }
        public string? DominioPredio { get; set; }
        public string? PreEscritura { get; set; }
        public string? PreNotaria { get; set; }
        public DateTime? PreFechaInscri { get; set; }
        public string? PreLugarInscri { get; set; }
        public string? PreRegProp { get; set; }
        public DateTime? PreFechareg { get; set; }
        public string? ObservacionesPredio { get; set; }
        public string? PreDimTomadoPlanos { get; set; }
        public string? PreOtraFuenteInf { get; set; }
        public string? PreDescnPropietario { get; set; }
        public string? PreLinderosDef { get; set; }
        public int? NuevoBloquePredio { get; set; }
        public int? NumAmpliacBloquePredio { get; set; }
        public string? TipoPredio { get; set; }
        public byte? ZonaDePromocionInmediata { get; set; }
        public string? EmplazamPredio { get; set; }
        public string? PreDimensionamiento { get; set; }
        public string? PropiedHorPredio { get; set; }
        public int? PreNumeroDivisiones { get; set; }
        public string? PrePathFoto { get; set; }
        public string? PreEstado { get; set; }
        public decimal? PreAreaTcartog { get; set; }
        public double? AlicuotaPredio { get; set; }
        public bool? BloqueConstruccion { get; set; }
        public string? PreOrganizacion { get; set; }
        public string? UsodelPredio { get; set; }
        public string? NombreUbicacion { get; set; }
        public string? ClaveMigrada { get; set; }
        public string? ClaveMigrada1 { get; set; }
        public string? Usuario { get; set; }
        public string? CalleSecundaria { get; set; }
        public string? Referencia { get; set; }

        public virtual Ciudadano? CiuCedulaNavigation { get; set; }
        public virtual Ubicacion? UbiCodigoNavigation { get; set; }
        public virtual ParametrosDeterminacionPredio? ParametrosDeterminacionPredio { get; set; }
        public virtual ICollection<AeLocal> AeLocals { get; set; }
        public virtual ICollection<BloquesPredio> BloquesPredios { get; set; }
        public virtual ICollection<CondicionesSolarNoEdificado> CondicionesSolarNoEdificados { get; set; }
        public virtual ICollection<DescripcionEdificacionPredio> DescripcionEdificacionPredios { get; set; }
        public virtual ICollection<InfraestrServiciosPredio> InfraestrServiciosPredios { get; set; }
        public virtual ICollection<PredioAccionesDerecho> PredioAccionesDerechoes { get; set; }
        public virtual ICollection<PredioComentario> PredioComentarios { get; set; }
        public virtual ICollection<PredioFrente> PredioFrentes { get; set; }
        public virtual ICollection<SmMejorasAux> SmMejorasAuxes { get; set; }
        public virtual ICollection<ValoresPeritaje> ValoresPeritajes { get; set; }
    }
}
