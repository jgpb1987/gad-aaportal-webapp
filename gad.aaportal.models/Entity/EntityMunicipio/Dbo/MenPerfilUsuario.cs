using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class MenPerfilUsuario
    {
        public int PusId { get; set; }
        public int UsuIdUsuario { get; set; }
        public int PerIdPerfil { get; set; }
        public string PusEstado { get; set; } = null!;
        public DateTime PusUltFecha { get; set; }
        public string PusUsuMod { get; set; } = null!;

        public virtual MenPerfil PerIdPerfilNavigation { get; set; } = null!;
        public virtual GenUsuario UsuIdUsuarioNavigation { get; set; } = null!;
    }
}
