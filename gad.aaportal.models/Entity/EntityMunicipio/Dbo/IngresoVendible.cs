using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class IngresoVendible
    {
        public int CodigoIngresoVendibles { get; set; }
        public string CodVendibleIngresoVendibles { get; set; } = null!;
        public int DesdeIngresoVendibles { get; set; }
        public int HastaIngresoVendibles { get; set; }
        public DateTime FechaIngresoVendibles { get; set; }
        public double ValorVendibles { get; set; }
        public double? ValorTotalVendibles { get; set; }
        public string? UserIngresoVendibles { get; set; }
        public string? Procesado { get; set; }
        public string? NumTramiteIngresoVendibles { get; set; }

        public virtual DescripcionVendible CodVendibleIngresoVendiblesNavigation { get; set; } = null!;
    }
}
