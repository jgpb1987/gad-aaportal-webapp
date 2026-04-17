using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeExoneracionExcedente
    {
        public int IdExoneracion { get; set; }
        public int? AnioCalculo { get; set; }
        public double? Rbu { get; set; }
        public double? PatrimonioAa { get; set; }
        public double? Ingresos { get; set; }
        public int? PorcentajeExoneracion { get; set; }
        /// <summary>
        /// P=Patrimonio
        /// I=Ingresos
        /// </summary>
        public string? ExedenteAplicado { get; set; }
        public double? PorcentajePatrimonio { get; set; }
        public double? PorcentajeIngreso { get; set; }
        public double? BaseImponible { get; set; }
        public double? ImpuestoGravado { get; set; }
        public double? PorcentajeAplicado { get; set; }
        public double? ValorExonerado { get; set; }
        public string? TipoImpuesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? UsuarioIngreso { get; set; }
        public int? IdCalculoImpuesto { get; set; }
        public double? ImpuestoTerceros { get; set; }
        public double? ValorExoneradoTerceros { get; set; }
        public int? IdRenunciaExoneracion { get; set; }
    }
}
