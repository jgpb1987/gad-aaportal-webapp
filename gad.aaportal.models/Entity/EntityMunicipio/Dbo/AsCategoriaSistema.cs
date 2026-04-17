using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsCategoriaSistema
    {
        public AsCategoriaSistema()
        {
            AsSistemas = new HashSet<AsSistema>();
        }

        public int IdCategoriaSistema { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }

        public virtual ICollection<AsSistema> AsSistemas { get; set; }
    }
}
