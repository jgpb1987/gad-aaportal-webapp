using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Prediobdd4
    {
        public string CodCatastralPredio { get; set; } = null!;
        public DateTime? FechaIntervencionPredio { get; set; }
        public string? Coddivpol { get; set; }
        public string? CodAnteriorPredio { get; set; }
        public string? UbiCodigo { get; set; }
        public string? CallePredio { get; set; }
        public string? NumeroPredio { get; set; }
        public string? NombrePredio { get; set; }
        public string? ProRucPropietario { get; set; }
        public string? CiuCedula { get; set; }
        public string? CedulaRepresLegPredio { get; set; }
        public string? PropAnteriorPredio { get; set; }
        public decimal? AreaTotalPredio { get; set; }
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
        public string? EmplazamPredio { get; set; }
        public string? PreDimensionamiento { get; set; }
        public string? PropiedHorPredio { get; set; }
        public int? PreNumeroDivisiones { get; set; }
        public string? PrePathFoto { get; set; }
        public string? PreEstado { get; set; }
        public decimal? PreAreaTcartog { get; set; }
        public double? AlicuotaPredio { get; set; }
        public bool? BloqueConstruccion { get; set; }
    }
}
