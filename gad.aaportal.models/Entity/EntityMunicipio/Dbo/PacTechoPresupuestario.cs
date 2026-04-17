using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacTechoPresupuestario
    {
        public int IdTechoPresupuestario { get; set; }
        public int? IdSubgrupo { get; set; }
        public double? Techo { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdCompra { get; set; }

        public virtual PacCompra? IdCompraNavigation { get; set; }
        public virtual PacSubGrupo? IdSubgrupoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
