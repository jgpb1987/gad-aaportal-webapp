using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class UsoSuelo
    {
        public UsoSuelo()
        {
            TipoUsoSuelos = new HashSet<TipoUsoSuelo>();
        }

        public string CodUsoSuelo { get; set; } = null!;
        public string? UsuSuDescripcion { get; set; }
        public string? UsoSuEstado { get; set; }

        public virtual ICollection<TipoUsoSuelo> TipoUsoSuelos { get; set; }
    }
}
