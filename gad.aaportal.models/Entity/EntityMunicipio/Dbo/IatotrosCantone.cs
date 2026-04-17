using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class IatotrosCantone
    {
        public int? CodIngTesoIat { get; set; }
        public string? Ruc { get; set; }
        public string? NroLocal { get; set; }
        public string? Canton { get; set; }
        public double? Porsentaje { get; set; }
        public double? Valor { get; set; }

        public virtual Local? Local { get; set; }
    }
}
