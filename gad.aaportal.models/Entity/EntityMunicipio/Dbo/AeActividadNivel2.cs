using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadNivel2
    {
        public AeActividadNivel2()
        {
            AeActividads = new HashSet<AeActividad>();
        }

        public string IdNivel2 { get; set; } = null!;
        public int? IdNivel1 { get; set; }
        public string? Descripcion { get; set; }

        public virtual AeActividadNivel1? IdNivel1Navigation { get; set; }
        public virtual ICollection<AeActividad> AeActividads { get; set; }
    }
}
