using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmMejora
    {
        public int IdObraPredio { get; set; }
        public int? CodigoDeObra { get; set; }
        public string? CodigoDeObraAnt { get; set; }
        public string? CodCatastralPredio { get; set; }
        public string? CodigoAnteriorPredio { get; set; }
        public string? Direccion { get; set; }
        public double? FrenteUno { get; set; }
        public double? FrenteDos { get; set; }
        public double? FrenteTres { get; set; }
        public double? ValorTerreno { get; set; }
        public double? Avaluo { get; set; }
        public int? CuotaEmitida { get; set; }
        public int? PlazosAnios { get; set; }
        public int? Sector { get; set; }
        public int? Cuenta { get; set; }
        public double? AliFrente { get; set; }
        public double? AliAvaluo { get; set; }
        public double? AliAdoquinado { get; set; }
        public double? AliAceras { get; set; }
        public double? AliAlcantarillado { get; set; }
        public double? AliAgua { get; set; }
        public double? TotalPagoAnual { get; set; }
        public double? TotalPagoMensual { get; set; }
        public double? TotalPagoPorObra { get; set; }
        public string? Observacion { get; set; }
        /// <summary>
        /// Estado de las mejoras  &apos;L&apos; Liquidación Total, &apos;T&apos; Pago total, &apos;E&apos; Mejoras a Emitir
        /// </summary>
        public string? Estado { get; set; }
        /// <summary>
        /// Estado en caso la obra sea dada de baja
        /// </summary>
        public string? ObraEstado { get; set; }
        public string? Usuario { get; set; }
        public string? EstadoEmision { get; set; }
        public double? ValorDescLiq { get; set; }
        public int? CodigoIngresoLiq { get; set; }

        public virtual SmObra? CodigoDeObraNavigation { get; set; }
    }
}
