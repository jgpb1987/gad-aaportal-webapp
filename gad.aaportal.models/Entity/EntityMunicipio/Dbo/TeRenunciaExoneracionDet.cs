using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeRenunciaExoneracionDet
    {
        public int IdDetalle { get; set; }
        public int? IdRenuncia { get; set; }
        public int? IdTipoRenuncia { get; set; }

        public virtual TeRenunciaExoneracion? IdRenunciaNavigation { get; set; }
        public virtual TeTipoRenunciaEx? IdTipoRenunciaNavigation { get; set; }
    }
}
