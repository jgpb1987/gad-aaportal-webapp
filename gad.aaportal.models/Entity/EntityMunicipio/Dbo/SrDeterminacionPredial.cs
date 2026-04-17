using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SrDeterminacionPredial
    {
        public int IdDeterminacion { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CedulaPropietario { get; set; }
        public string? Anio { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorConstruccion { get; set; }
        public double? ValorComercial { get; set; }
        public string? TipoPredio { get; set; }
        public double? BaseImponible { get; set; }
        public double? ValorImpuesto { get; set; }
        public double? ValorSolar { get; set; }
        public double? TasaBomberos { get; set; }
        public double? TasaAdministrativa { get; set; }
        public double? PorcentajeImpuesto { get; set; }
        public double? PorcentajeBomberos { get; set; }
        public double? ValorEmitido { get; set; }
        public double? ValorDescuento { get; set; }
        public string? TipoDescuento { get; set; }
        /// <summary>
        /// Motivo del porque no se emitio un valor
        /// </summary>
        public string? NoEmision { get; set; }
        /// <summary>
        /// Estados la D=Determinado y E=No determinado
        /// </summary>
        public string? EstadoDet { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Usuario { get; set; }
        public double? ValorDescuentoTerceros { get; set; }
        public int? CodigoIngreso { get; set; }
        /// <summary>
        /// Que si en la datos de ingreso se da la baja en este estado se pone &apos;B&apos;
        /// Si se borra el registro de la datos de ingreso en esta tabla se pone &apos;E&apos;
        /// </summary>
        public string? EstadoEmision { get; set; }
    }
}
