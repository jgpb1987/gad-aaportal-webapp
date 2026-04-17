using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SnTipoNotificacion
    {
        public SnTipoNotificacion()
        {
            SnNotificaciones = new HashSet<SnNotificacione>();
        }

        public int Id { get; set; }
        public string? Tipo { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual SnDepartamento? IdDepartamentoNavigation { get; set; }
        public virtual ICollection<SnNotificacione> SnNotificaciones { get; set; }
    }
}
