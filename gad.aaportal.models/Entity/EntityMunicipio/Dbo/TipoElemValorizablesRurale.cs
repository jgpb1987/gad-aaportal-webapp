using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoElemValorizablesRurale
    {
        public TipoElemValorizablesRurale()
        {
            ClaseElemValorizablesRurales = new HashSet<ClaseElemValorizablesRurale>();
        }

        public string CodTipoElemValorizablesRurales { get; set; } = null!;
        public string? DescripcionTipoFactoresRurales { get; set; }
        public string? CodElemValorizablesRurales { get; set; }

        public virtual ElemValorizablesRurale? CodElemValorizablesRuralesNavigation { get; set; }
        public virtual ICollection<ClaseElemValorizablesRurale> ClaseElemValorizablesRurales { get; set; }
    }
}
