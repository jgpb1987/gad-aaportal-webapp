using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmRecalculo
    {
        public int IdRecalculo { get; set; }
        public int? CodigoObra { get; set; }
        public string? CodigoObraAnt { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Cedula { get; set; }
        public double? TotalEmitido { get; set; }
        public int? TipoMejora { get; set; }
        public int? AnioEmitido { get; set; }
        public int? AnioXemitir { get; set; }
        public double? TotalAemitir { get; set; }
        public double? ValorAemitirAnual { get; set; }
        public int? IdAux { get; set; }
        public string? EstadoEx { get; set; }
    }
}
