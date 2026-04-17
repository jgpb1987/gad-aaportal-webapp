using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmMejorasAux
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
        /// <summary>
        /// Si el estado es P (Obra Preliminar) si el estado es D (Obra es definitiva)
        /// Si el estado es P (Obra Preliminar) si el estado es D (Obra es definitiva)
        /// </summary>
        public string? EstadoObra { get; set; }
        /// <summary>
        /// El estado que indica en que dependencia se encuentra el proceso
        /// &apos;O&apos;(Obras Publicas), &apos;A&apos;(Avaluos y Catastros), &apos;R&apos;(Rentas)
        /// </summary>
        public string? EstadoDep { get; set; }
        public double? ValorMejora { get; set; }
        /// <summary>
        /// Si el predio es urbano o rural
        /// </summary>
        public string? TipoPredio { get; set; }
        /// <summary>
        /// Si el predio es institucion pública no envia a generar título de crédito &apos;N&apos;
        /// </summary>
        public string? EstadoMejora { get; set; }
        public string? EstadoCambiaFrente { get; set; }
        public string? Observaciones { get; set; }
        public double? FrenteCuatro { get; set; }
        public double? FrenteTotal { get; set; }
        public double? ValorPropiedadCal { get; set; }
        public string? EstadoExcluir { get; set; }
        public string? ObservacionExclusion { get; set; }

        public virtual Predio? ClaveCatastralNavigation { get; set; }
        public virtual SmObra? CodigoDeObraNavigation { get; set; }
        public virtual SmTipoMejora? TipoMejoraNavigation { get; set; }
    }
}
