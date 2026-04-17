using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Paise
    {
        public Paise()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public string Pais { get; set; } = null!;

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
