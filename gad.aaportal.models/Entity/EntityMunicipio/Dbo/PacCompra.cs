using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacCompra
    {
        public PacCompra()
        {
            PacDetalleCompras = new HashSet<PacDetalleCompra>();
            PacTechoPresupuestarios = new HashSet<PacTechoPresupuestario>();
        }

        public int IdCompra { get; set; }
        public int? IdDependencia { get; set; }
        public int? Anio { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Estado { get; set; }

        public virtual PacDependencia? IdDependenciaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<PacDetalleCompra> PacDetalleCompras { get; set; }
        public virtual ICollection<PacTechoPresupuestario> PacTechoPresupuestarios { get; set; }
    }
}
