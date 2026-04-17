using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Predioame
    {
        public string PreCodigoCatastral { get; set; } = null!;
        public DateTime? PreFechaIngreso { get; set; }
        public string? DivPoCodigo { get; set; }
        public string? PreCodigoAnterior { get; set; }
        public string? UbiCodigo { get; set; }
        public string? PreNumero { get; set; }
        public string? PreNombrePredio { get; set; }
        public string? ProRucPropietario { get; set; }
        public string? CiuCedula { get; set; }
        public string? CiuRepLegal { get; set; }
        public string? PrePropietarioAnterior { get; set; }
        public decimal? PreAreaTotalTer { get; set; }
        public decimal? PreAreaTotalConst { get; set; }
        public decimal? PreFrentePrincipal { get; set; }
        public decimal? PreFondoRelativo { get; set; }
        public decimal? PreFrenteFondo { get; set; }
        public string? PreDominio { get; set; }
        public string? PreEscritura { get; set; }
        public string? PreNotaria { get; set; }
        public DateTime? PreFechaInscri { get; set; }
        public string? PreLugarInscri { get; set; }
        public string? PreRegProp { get; set; }
        public DateTime? PreFechareg { get; set; }
        public string? PreObservaciones { get; set; }
        public string? PreDimTomadoPlanos { get; set; }
        public string? PreOtraFuenteInf { get; set; }
        public string? PreDescnPropietario { get; set; }
        public string? PreLinderosDef { get; set; }
        public int? PreNumNuevoBloque { get; set; }
        public int? PreNumAmpliBloque { get; set; }
        public string? PreTipo { get; set; }
        public string? PreEmplazamiento { get; set; }
        public string? PreDimensionamiento { get; set; }
        public string? PrePropiedadHorizontal { get; set; }
        public int? PreNumeroDivisiones { get; set; }
        public string? PrePathFoto { get; set; }
        public string? PreEstado { get; set; }
        public decimal? PreAreaTcartog { get; set; }
    }
}
