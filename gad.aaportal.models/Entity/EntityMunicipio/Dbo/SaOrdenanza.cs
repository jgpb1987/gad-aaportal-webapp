using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaOrdenanza
    {
        public SaOrdenanza()
        {
            SaArticulosOrdenanzas = new HashSet<SaArticulosOrdenanza>();
        }

        public int IdOrdenanza { get; set; }
        public string? NombreOrdenanza { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<SaArticulosOrdenanza> SaArticulosOrdenanzas { get; set; }
    }
}
