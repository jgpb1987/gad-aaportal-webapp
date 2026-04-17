using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteCxCsaldoMe
    {
        public int CodSaldos { get; set; }
        public string? CodContableCxC { get; set; }
        public string? DescripcionCxC { get; set; }
        public double? Ingreso { get; set; }
        public double? Recaudacion { get; set; }
        public double? Baja { get; set; }
        public double? Saldo { get; set; }
        public short? Mes { get; set; }
        public short? Año { get; set; }
        public string? Tipo { get; set; }
        public string? Estado { get; set; }
    }
}
