using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItImpresora
    {
        public ItImpresora()
        {
            ItToners = new HashSet<ItToner>();
        }

        public int Id { get; set; }
        public string? Area { get; set; }
        public string? Bodega { get; set; }
        public bool? DadaDeBaja { get; set; }
        public string? PartidaArea { get; set; }
        public DateTime? GarantiaHastaCuando { get; set; }

        public virtual ItEquipo IdNavigation { get; set; } = null!;
        public virtual ICollection<ItToner> ItToners { get; set; }
    }
}
