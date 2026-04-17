using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaInformacionSri
    {
        public string ClaveCatastral { get; set; } = null!;
        public string TipoPredio { get; set; } = null!;
        public string TipoIdentificacion { get; set; } = null!;
        public string NumeroIdentificacion { get; set; } = null!;
        public string? NombreRazonSocial { get; set; }
        public string? CodigoParroquia { get; set; }
        public string? DireccionPredio { get; set; }
        public decimal? AreaTotalPredio { get; set; }
        public string UnidadMedidaAreaTotal { get; set; } = null!;
        public decimal? AreaConstruccion { get; set; }
        public string UnidadMedidaAreaConstruccion { get; set; } = null!;
        public decimal? AvaluoTotalPredio { get; set; }
        public DateTime? FechaInsRegistroPropiedad { get; set; }
        public string? UbicacionAux { get; set; }
        public string? NombrePredio { get; set; }
    }
}
