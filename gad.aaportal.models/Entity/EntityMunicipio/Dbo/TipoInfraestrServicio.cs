using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TipoInfraestrServicio
    {
        public TipoInfraestrServicio()
        {
            InfraestrServiciosPredios = new HashSet<InfraestrServiciosPredio>();
        }

        public string CodTipoInfraestrServicios { get; set; } = null!;
        public string? DescripcionTipoInfraestrServicios { get; set; }
        public decimal? CoeficienteTipoInfraestrServicios { get; set; }
        public string? EstadoTipoInfraestrServicios { get; set; }
        public string? InfSeCodigoFicha { get; set; }
        public string? InfSeTipoPredio { get; set; }
        public string? CodInfraestrServicios { get; set; }

        public virtual InfraestrServicio? CodInfraestrServiciosNavigation { get; set; }
        public virtual ICollection<InfraestrServiciosPredio> InfraestrServiciosPredios { get; set; }
    }
}
