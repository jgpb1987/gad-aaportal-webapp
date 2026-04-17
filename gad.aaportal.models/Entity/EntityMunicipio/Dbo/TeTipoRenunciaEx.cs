using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeTipoRenunciaEx
    {
        public TeTipoRenunciaEx()
        {
            TeRenunciaExoneracionDets = new HashSet<TeRenunciaExoneracionDet>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<TeRenunciaExoneracionDet> TeRenunciaExoneracionDets { get; set; }
    }
}
