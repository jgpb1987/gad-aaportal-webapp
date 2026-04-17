using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ElemValorizablesRurale
    {
        public ElemValorizablesRurale()
        {
            TipoElemValorizablesRurales = new HashSet<TipoElemValorizablesRurale>();
        }

        public string CodElemValorizablesRurales { get; set; } = null!;
        public string? DescripcionFactoresRurales { get; set; }
        public string? DescripcionTipoFactoresRurales { get; set; }

        public virtual ICollection<TipoElemValorizablesRurale> TipoElemValorizablesRurales { get; set; }
    }
}
