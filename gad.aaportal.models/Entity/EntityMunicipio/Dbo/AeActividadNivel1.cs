using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeActividadNivel1
    {
        public AeActividadNivel1()
        {
            AeActividadNivel2s = new HashSet<AeActividadNivel2>();
        }

        public int IdNivel1 { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<AeActividadNivel2> AeActividadNivel2s { get; set; }
    }
}
