using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AePersonerium
    {
        public AePersonerium()
        {
            AeIdentificacionContribuyentes = new HashSet<AeIdentificacionContribuyente>();
        }

        public int IdPersoneria { get; set; }
        public string? Personeria { get; set; }

        public virtual ICollection<AeIdentificacionContribuyente> AeIdentificacionContribuyentes { get; set; }
    }
}
