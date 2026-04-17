using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItTonersTipo
    {
        public ItTonersTipo()
        {
            ItToners = new HashSet<ItToner>();
        }

        public string Descripcion { get; set; } = null!;

        public virtual ICollection<ItToner> ItToners { get; set; }
    }
}
