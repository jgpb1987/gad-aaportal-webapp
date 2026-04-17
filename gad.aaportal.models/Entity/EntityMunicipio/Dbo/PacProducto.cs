using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacProducto
    {
        public PacProducto()
        {
            PacDetalleCompras = new HashSet<PacDetalleCompra>();
        }

        public int IdProducto { get; set; }
        public int IdSubGrupo { get; set; }
        public string NombreProducto { get; set; } = null!;
        public double ValorProducto { get; set; }
        public int IdUnidadMedidaProducto { get; set; }
        public string? Cpc { get; set; }
        public bool? Estado { get; set; }
        public int? IdPacDescripcionCompra { get; set; }
        public int? IdTipoCompra { get; set; }

        public virtual PacDescripcionCompraProducto? IdPacDescripcionCompraNavigation { get; set; }
        public virtual PacSubGrupo IdSubGrupoNavigation { get; set; } = null!;
        public virtual PacTipoCompra? IdTipoCompraNavigation { get; set; }
        public virtual PacUnidadMedidum IdUnidadMedidaProductoNavigation { get; set; } = null!;
        public virtual ICollection<PacDetalleCompra> PacDetalleCompras { get; set; }
    }
}
