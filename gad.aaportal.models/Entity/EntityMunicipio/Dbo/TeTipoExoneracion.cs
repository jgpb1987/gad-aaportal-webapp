using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeTipoExoneracion
    {
        public TeTipoExoneracion()
        {
            TeExoneracionesPersonas = new HashSet<TeExoneracionesPersona>();
        }

        public int IdTipoExoneracion { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<TeExoneracionesPersona> TeExoneracionesPersonas { get; set; }
    }
}
