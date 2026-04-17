using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClaseElemValorizablesRurale
    {
        public string CodClaseElemValorizablesRurales { get; set; } = null!;
        public string? DescripcionClaseFactoresRurales { get; set; }
        public string? CodTipoElemValorizablesRurales { get; set; }

        public virtual TipoElemValorizablesRurale? CodTipoElemValorizablesRuralesNavigation { get; set; }
    }
}
