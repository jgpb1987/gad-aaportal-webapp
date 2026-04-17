using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DesgloseTitulosTasa
    {
        public decimal? CodTitulosTasasPredio { get; set; }
        public decimal? OrdenDesgloseTitulos { get; set; }
        public double? CantidadDesgloseTitulos { get; set; }
        public double? ValorDesgloseTitulos { get; set; }
        public string? CodOrdenanza { get; set; }
    }
}
