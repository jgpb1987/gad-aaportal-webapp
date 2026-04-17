using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Valor
    {
        public int CodIngreso { get; set; }
        public int Orden { get; set; }
        public double? Valor1 { get; set; }
        public int? CodigoDescripcion { get; set; }

        public virtual DatosIngreso CodIngresoNavigation { get; set; } = null!;
        public virtual DescripcionTitulo? CodigoDescripcionNavigation { get; set; }
    }
}
