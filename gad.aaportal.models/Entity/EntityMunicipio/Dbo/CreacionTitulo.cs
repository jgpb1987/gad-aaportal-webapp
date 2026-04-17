using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CreacionTitulo
    {
        public int? CodCreacionTitulo { get; set; }
        public int? CodDescipcion { get; set; }
        public int? Orden { get; set; }
        public int Cod { get; set; }

        public virtual Titulo? CodCreacionTituloNavigation { get; set; }
        public virtual DescripcionTitulo? CodDescipcionNavigation { get; set; }
    }
}
