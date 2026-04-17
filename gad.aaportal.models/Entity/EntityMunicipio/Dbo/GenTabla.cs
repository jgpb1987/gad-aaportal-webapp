using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenTabla
    {
        public GenTabla()
        {
            GenCatalogos = new HashSet<GenCatalogo>();
        }

        public int TabCodigo { get; set; }
        public string TabTabla { get; set; } = null!;
        public string TabDescripcion { get; set; } = null!;
        public int TabEstado { get; set; }

        public virtual ICollection<GenCatalogo> GenCatalogos { get; set; }
    }
}
