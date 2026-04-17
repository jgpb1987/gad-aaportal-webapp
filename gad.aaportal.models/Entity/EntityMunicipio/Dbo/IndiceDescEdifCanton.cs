using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class IndiceDescEdifCanton
    {
        public IndiceDescEdifCanton()
        {
            DescripcionEdificacionPredios = new HashSet<DescripcionEdificacionPredio>();
        }

        public int CodIndiceDescripcionEdificacionCanton { get; set; }
        public int? CodClaseDescripcionEdificacion { get; set; }
        public decimal? IndiceDescripcionEdificacionCanton { get; set; }
        public decimal? IndiceDescripcionEdificacionCantonR { get; set; }
        public string? Coddivpol { get; set; }

        public virtual ClaseDescripcionEdificacion? CodClaseDescripcionEdificacionNavigation { get; set; }
        public virtual ICollection<DescripcionEdificacionPredio> DescripcionEdificacionPredios { get; set; }
    }
}
