using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalAnualPago
    {
        public int IdLocalAnualPagos { get; set; }
        public int? IdLocalAnual { get; set; }
        public string? Institucion { get; set; }
        public string? NroComprobante { get; set; }
        public double? Valor { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Diferencia { get; set; }
        public string? Observacion { get; set; }
        public string? Tipo { get; set; }

        public virtual LocalAnual? IdLocalAnualNavigation { get; set; }
    }
}
