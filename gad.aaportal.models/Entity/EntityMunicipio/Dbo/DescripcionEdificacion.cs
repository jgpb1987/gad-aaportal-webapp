using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionEdificacion
    {
        public DescripcionEdificacion()
        {
            TipoDescripcionEdificacions = new HashSet<TipoDescripcionEdificacion>();
        }

        public int CodDescripcionEdificacion { get; set; }
        public string CodDescripcionEdificacionAux { get; set; } = null!;
        public string? DescripcionDecripcionEdificacion { get; set; }
        public string? EstadoDescripcionEdificacion { get; set; }
        public string? DesEdCodigoFicha { get; set; }

        public virtual ICollection<TipoDescripcionEdificacion> TipoDescripcionEdificacions { get; set; }
    }
}
