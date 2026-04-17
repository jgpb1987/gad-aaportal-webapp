using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiTransferenciaDominio
    {
        public int IdDominio { get; set; }
        public string? Dominio { get; set; }
        public double? PorcentajeBaseCobro { get; set; }
        public string? EstadoAlcabala { get; set; }
        public double? PorcentajeDescuento { get; set; }
        public string? EstadoPlusvalia { get; set; }
    }
}
