using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SnDepartamento
    {
        public SnDepartamento()
        {
            SnTipoNotificacions = new HashSet<SnTipoNotificacion>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<SnTipoNotificacion> SnTipoNotificacions { get; set; }
    }
}
