using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClaseDescripcionEdificacion
    {
        public ClaseDescripcionEdificacion()
        {
            IndiceDescEdifCantons = new HashSet<IndiceDescEdifCanton>();
        }

        public int CodClaseDescripcionEdificacion { get; set; }
        public string CodClaseDescripcionEdificacionAux { get; set; } = null!;
        public string? DescripcionClaseDescripcionEdificacion { get; set; }
        public decimal? DesEdCoefUrb { get; set; }
        public decimal? DesEdCoefRur { get; set; }
        public string? EstadoClaseDescripcionEdificacion { get; set; }
        public string? DesEdCodigoFicha { get; set; }
        public string? CodTipoDescripcionEdificacionAux { get; set; }
        public int? CodTipoDescripcionEdificacion { get; set; }

        public virtual TipoDescripcionEdificacion? CodTipoDescripcionEdificacionNavigation { get; set; }
        public virtual ICollection<IndiceDescEdifCanton> IndiceDescEdifCantons { get; set; }
    }
}
