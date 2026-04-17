using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoDescripcionEdificacion
    {
        public TipoDescripcionEdificacion()
        {
            ClaseDescripcionEdificacions = new HashSet<ClaseDescripcionEdificacion>();
        }

        public int CodTipoDescripcionEdificacion { get; set; }
        public string CodTipoDescripcionEdificacionAux { get; set; } = null!;
        public string? DescripcionTipoDescripcionEdificacion { get; set; }
        public string? EstadoTipoDescripcionEdificacion { get; set; }
        public string? DesEdCodigoFicha { get; set; }
        public string? CodDescripcionEdificacionAux { get; set; }
        public int? CodDescripcionEdificacion { get; set; }

        public virtual DescripcionEdificacion? CodDescripcionEdificacionNavigation { get; set; }
        public virtual ICollection<ClaseDescripcionEdificacion> ClaseDescripcionEdificacions { get; set; }
    }
}
