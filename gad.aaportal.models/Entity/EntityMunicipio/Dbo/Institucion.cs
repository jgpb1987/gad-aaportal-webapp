using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Institucion
    {
        public string InsRuc { get; set; } = null!;
        public string? InsNombre { get; set; }
        public string? TipOrCodigo { get; set; }

        public virtual TipoOrganizacion? TipOrCodigoNavigation { get; set; }
    }
}
