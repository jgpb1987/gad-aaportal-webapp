using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Prediofoto
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? PathFoto1 { get; set; }
        public string? NombreFoto { get; set; }
        public string? PathFoto { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
    }
}
