using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SnNotificacione
    {
        public SnNotificacione()
        {
            SnRazonNotificacions = new HashSet<SnRazonNotificacion>();
            SnRazonPatentes = new HashSet<SnRazonPatente>();
        }

        public int Id { get; set; }
        public string? CedulaCiu { get; set; }
        public string? TipoNotificacion { get; set; }
        public string? CorreoEnvio { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string? UsuarioEnvio { get; set; }
        public int? IdTipo { get; set; }

        public virtual SnTipoNotificacion? IdTipoNavigation { get; set; }
        public virtual ICollection<SnRazonNotificacion> SnRazonNotificacions { get; set; }
        public virtual ICollection<SnRazonPatente> SnRazonPatentes { get; set; }
    }
}
