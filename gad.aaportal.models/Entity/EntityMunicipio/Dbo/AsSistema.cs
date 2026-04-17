using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsSistema
    {
        public AsSistema()
        {
            AsAccesos = new HashSet<AsAcceso>();
            AsMenuSistemas = new HashSet<AsMenuSistema>();
            AsRegistroDeMovimientos = new HashSet<AsRegistroDeMovimiento>();
        }

        public int IdSistema { get; set; }
        public string Nombre { get; set; } = null!;
        public string Version { get; set; } = null!;
        public bool? Visible { get; set; }
        public int? IdCategoriaSistema { get; set; }
        public string? Path { get; set; }
        public bool? SitioWeb { get; set; }
        public string? PathCodigoFuente { get; set; }

        public virtual AsCategoriaSistema? IdCategoriaSistemaNavigation { get; set; }
        public virtual ICollection<AsAcceso> AsAccesos { get; set; }
        public virtual ICollection<AsMenuSistema> AsMenuSistemas { get; set; }
        public virtual ICollection<AsRegistroDeMovimiento> AsRegistroDeMovimientos { get; set; }
    }
}
