using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ClaseTierra
    {
        public int CodClaseTierra { get; set; }
        public int? CodInfluencias { get; set; }
        public string? DescripcionClaseTierra { get; set; }
        public int? PuntajeClaseTierra { get; set; }
        public decimal? CoeficienteCorreccionClaseTierra { get; set; }
        public int? CodigoClaseTierra { get; set; }

        public virtual Influencia? CodInfluenciasNavigation { get; set; }
    }
}
