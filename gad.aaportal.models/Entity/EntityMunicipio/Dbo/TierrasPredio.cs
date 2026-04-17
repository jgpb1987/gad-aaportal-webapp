using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TierrasPredio
    {
        public string? CodCatastralPredio { get; set; }
        public string? CodClaseElemValorizablesRurales { get; set; }
        public int? CodPlantacionConservacion { get; set; }
        public decimal? SuperficieTierra { get; set; }
        public int? NumPlantasHectarea { get; set; }
        public int? EdadPlantacion { get; set; }
        public decimal? ValorTierra { get; set; }

        public virtual Predio? CodCatastralPredioNavigation { get; set; }
        public virtual ClaseElemValorizablesRurale? CodClaseElemValorizablesRuralesNavigation { get; set; }
        public virtual PlantacionConservacion? CodPlantacionConservacionNavigation { get; set; }
    }
}
