using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ValorAplicEdificacion
    {
        public string ValApECodigo { get; set; } = null!;
        public decimal? ValApEHormigon { get; set; }
        public decimal? ValApEHierro { get; set; }
        public decimal? ValApEMaderaFina { get; set; }
        public decimal? ValApEMaderaComun { get; set; }
        public decimal? ValApEBloqueLadrillo { get; set; }
        public decimal? ValApEBahareque { get; set; }
        public decimal? ValApEAdobeTapial { get; set; }
        public decimal? ValApEEstable { get; set; }
        public decimal? ValApEAreparar { get; set; }
        public decimal? ValApEObsoleto { get; set; }
        public decimal? IndiceOrden { get; set; }
    }
}
