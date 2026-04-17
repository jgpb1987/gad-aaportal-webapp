using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItToner
    {
        public int Id { get; set; }
        public int? Idimpresora { get; set; }
        public string? Descripcion { get; set; }
        public string? Cpc { get; set; }
        public bool? Repuesto { get; set; }
        public int? Stock { get; set; }
        public int? Acomprar { get; set; }
        public double? ValorUnitario { get; set; }

        public virtual ItTonersTipo? DescripcionNavigation { get; set; }
        public virtual ItImpresora? IdimpresoraNavigation { get; set; }
    }
}
