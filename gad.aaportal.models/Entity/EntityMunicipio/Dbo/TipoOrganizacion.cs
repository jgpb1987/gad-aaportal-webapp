using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoOrganizacion
    {
        public string CodTipoOrganizacion { get; set; } = null!;
        public string? TipOrCodigoPadre { get; set; }
        public string? DescripcionTipoOrganizacion { get; set; }
    }
}
