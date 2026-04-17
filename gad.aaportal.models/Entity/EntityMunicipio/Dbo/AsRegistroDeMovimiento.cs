using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsRegistroDeMovimiento
    {
        public AsRegistroDeMovimiento()
        {
            AsDetalleRegistroDeMovimientos = new HashSet<AsDetalleRegistroDeMovimiento>();
        }

        public long Codigo { get; set; }
        public DateTime FechaHora { get; set; }
        public string UsuarioDelSistema { get; set; } = null!;
        public int Sistema { get; set; }
        public string Modulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Clave { get; set; }

        public virtual AsSistema SistemaNavigation { get; set; } = null!;
        public virtual ICollection<AsDetalleRegistroDeMovimiento> AsDetalleRegistroDeMovimientos { get; set; }
    }
}
