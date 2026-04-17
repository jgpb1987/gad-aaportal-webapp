using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AuxEmision
    {
        public string? ClaveCatastral { get; set; }
        public double? NumBloques { get; set; }
        public double? DConservacion { get; set; }
        public string? TipoPredio { get; set; }
        public double? IContNumBloque { get; set; }
        public double? IPorcentajeRepacion { get; set; }
        public double? IAnosConstruccion { get; set; }
        public double? SumatoriaIndice { get; set; }
        public double? ConstateRepocicion { get; set; }
        public double? DDepreciacionEdificacion { get; set; }
        public double? DVmc { get; set; }
        public double? DValorComercialEdificacionBloque { get; set; }
        public double? BloqueObsoleto { get; set; }
        public string? ExclusivoOcomunal { get; set; }
        public double? DValorComercialEdificacionBloqueComunal { get; set; }
        public double? DValorComercialEdificacionBloqueExclusivo { get; set; }
        public double? DValorComercialEdificacionTotal { get; set; }
    }
}
