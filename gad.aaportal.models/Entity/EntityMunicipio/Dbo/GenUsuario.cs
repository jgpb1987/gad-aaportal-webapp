using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenUsuario
    {
        public GenUsuario()
        {
            MenPerfilUsuarios = new HashSet<MenPerfilUsuario>();
        }

        public int UsuIdUsuario { get; set; }
        public int GemCodigo { get; set; }
        public string UsuEstado { get; set; } = null!;
        public string UsuLogin { get; set; } = null!;
        public string UsuClave { get; set; } = null!;
        public string UsuActiveDirectory { get; set; } = null!;
        public DateTime UsuUltFecha { get; set; }
        public string? EmpCodigo { get; set; }
        public bool? UsuModalidadUsuario { get; set; }
        public bool? UsuModalidadPolitica { get; set; }

        public virtual ICollection<MenPerfilUsuario> MenPerfilUsuarios { get; set; }
    }
}
