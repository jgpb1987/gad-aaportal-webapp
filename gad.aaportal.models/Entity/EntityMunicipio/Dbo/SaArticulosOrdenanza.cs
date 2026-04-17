using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaArticulosOrdenanza
    {
        public SaArticulosOrdenanza()
        {
            SaLiteralesArticulos = new HashSet<SaLiteralesArticulo>();
        }

        public int IdArticulo { get; set; }
        public int? IdOrdenanza { get; set; }
        public int? NumeroArticulo { get; set; }
        public string? DescripcionArticulo { get; set; }
        public int? IdTituloOrdenanza { get; set; }

        public virtual SaOrdenanza? IdOrdenanzaNavigation { get; set; }
        public virtual ICollection<SaLiteralesArticulo> SaLiteralesArticulos { get; set; }
    }
}
