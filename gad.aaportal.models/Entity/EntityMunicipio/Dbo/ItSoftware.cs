using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItSoftware
    {
        public int? Idequipo { get; set; }
        public string? Descripcion { get; set; }
        public string? Licencia { get; set; }

        public virtual ItSoftwareTipo? DescripcionNavigation { get; set; }
        public virtual ItEquipo? IdequipoNavigation { get; set; }
    }
}
