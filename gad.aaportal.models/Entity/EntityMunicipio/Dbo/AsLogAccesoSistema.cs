using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsLogAccesoSistema
    {
        public AsLogAccesoSistema()
        {
            AsLogAccesoFallidos = new HashSet<AsLogAccesoFallido>();
            AsLogIngresoSistemas = new HashSet<AsLogIngresoSistema>();
        }

        public long IdAcceso { get; set; }
        public string NombreMaquina { get; set; } = null!;
        public string IpMaquina { get; set; } = null!;
        public string NombreDeUsuario { get; set; } = null!;
        public DateTime FechaHora { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public bool IntentoFallido { get; set; }

        public virtual AsMaquina IpMaquinaNavigation { get; set; } = null!;
        public virtual ICollection<AsLogAccesoFallido> AsLogAccesoFallidos { get; set; }
        public virtual ICollection<AsLogIngresoSistema> AsLogIngresoSistemas { get; set; }
    }
}
