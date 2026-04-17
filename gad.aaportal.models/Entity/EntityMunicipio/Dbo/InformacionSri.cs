using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class InformacionSri
    {
        public string ClaveCatastral { get; set; } = null!;
        public string TipoPredio { get; set; } = null!;
        public string TipoIdentificacion { get; set; } = null!;
        public string? NumeroIdentificacion { get; set; }
        public string? NombreRazonSocial { get; set; }
        public string? CodigoParroquia { get; set; }
        public string DireccionPredio { get; set; } = null!;
        public decimal AreaTotalPredio { get; set; }
        public string UnidadMedidaAreaTotal { get; set; } = null!;
        public decimal AreaConstruccion { get; set; }
        public string UnidadMedidaAreaConst { get; set; } = null!;
        public decimal AvaluoTotalPredio { get; set; }
        public DateTime? FechaInsRegistroPropiedad { get; set; }
    }
}
