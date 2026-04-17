using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApTramaLecturaRespuestum
    {
        public int CodigoIngreso { get; set; }
        public string? TramaRecibida { get; set; }
        public int? Sector { get; set; }
        public int? Cuenta { get; set; }
        public string? Medidor { get; set; }
        public decimal? ConsumoPeriodo { get; set; }
        public double? SaldoCliente { get; set; }
        public int? NumMesesDeuda { get; set; }
        public string? MetodoProceso { get; set; }
        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public string? Anio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string? Auxiliar { get; set; }
    }
}
