using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CarteraAux
    {
        public double? ValorTotal { get; set; }
        public string CodTituloDatos { get; set; } = null!;
        public double? Descuento { get; set; }
        public double? Recargo { get; set; }
        public double? Interes { get; set; }
        public int? NumTitulos { get; set; }
        public double? Valor { get; set; }
        public int Orden { get; set; }
    }
}
