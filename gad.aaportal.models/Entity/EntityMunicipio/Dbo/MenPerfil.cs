using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MenPerfil
    {
        public MenPerfil()
        {
            MenPerfilMenus = new HashSet<MenPerfilMenu>();
            MenPerfilUsuarios = new HashSet<MenPerfilUsuario>();
        }

        public int PerIdperfil { get; set; }
        public string PerNombre { get; set; } = null!;
        public string PerEstado { get; set; } = null!;
        public int PerAdmin { get; set; }
        public int PerContador { get; set; }
        public int PerReps { get; set; }
        public DateTime PerUltFecha { get; set; }
        public int? PerCodestado { get; set; }
        public string? PerUsuario { get; set; }

        public virtual ICollection<MenPerfilMenu> MenPerfilMenus { get; set; }
        public virtual ICollection<MenPerfilUsuario> MenPerfilUsuarios { get; set; }
    }
}
