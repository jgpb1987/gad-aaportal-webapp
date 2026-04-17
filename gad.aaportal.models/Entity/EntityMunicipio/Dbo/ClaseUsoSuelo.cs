using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClaseUsoSuelo
    {
        public string CodClaseUsoSuelo { get; set; } = null!;
        public string? DescripcionClaseUsoSuelo { get; set; }
        public string? EstadoClaseUsoSuelo { get; set; }
        public string? CodTipoUsoSuelo { get; set; }

        public virtual TipoUsoSuelo? CodTipoUsoSueloNavigation { get; set; }
    }
}
