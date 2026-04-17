using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoUsoSuelo
    {
        public TipoUsoSuelo()
        {
            ClaseUsoSuelos = new HashSet<ClaseUsoSuelo>();
        }

        public string CodTipoUsoSuelo { get; set; } = null!;
        public string? DescripcionTipoUsoSuelo { get; set; }
        public string? EstadoTipoUsoSuelo { get; set; }
        public string? CodUsoSuelo { get; set; }

        public virtual UsoSuelo? CodUsoSueloNavigation { get; set; }
        public virtual ICollection<ClaseUsoSuelo> ClaseUsoSuelos { get; set; }
    }
}
