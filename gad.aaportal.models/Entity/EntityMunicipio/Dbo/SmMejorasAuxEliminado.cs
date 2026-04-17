using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmMejorasAuxEliminado
    {
        public int IdAux { get; set; }
        public int? CodigoDeObra { get; set; }
        public string? CodigoDeObraAnt { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? ClaveCatastralAnt { get; set; }
        public string? CallePredio { get; set; }
        public int? PlazosAnios { get; set; }
        public string? Cedula { get; set; }
        public double? FrenteUno { get; set; }
        public double? FrenteDos { get; set; }
        public double? FrenteTres { get; set; }
        public double? AreaTotalPredio { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorPropiedad { get; set; }
        public double? AvaluoTerreno { get; set; }
        public int? TipoMejora { get; set; }
        public string? EstadoObra { get; set; }
        public string? EstadoDep { get; set; }
        public double? ValorMejora { get; set; }
        public string? TipoPredio { get; set; }
        public string? EstadoMejora { get; set; }
        public string? EstadoCambiaFrente { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
