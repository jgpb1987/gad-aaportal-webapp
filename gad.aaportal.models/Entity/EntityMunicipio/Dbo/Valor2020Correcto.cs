using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Valor2020Correcto
    {
        public int CodIngreso { get; set; }
        public int Orden { get; set; }
        public double? Valor { get; set; }
        public int? CodigoDescripcion { get; set; }
    }
}
