using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class InfraestrServicio
    {
        public InfraestrServicio()
        {
            TipoInfraestrServicios = new HashSet<TipoInfraestrServicio>();
        }

        public string CodInfraestrServicios { get; set; } = null!;
        public string? DescripcionInfraestrServicios { get; set; }
        public string? EstadoInfraestrServicios { get; set; }
        public string? InfSeCodigoFicha { get; set; }
        public string? InfSeTipoPredio { get; set; }

        public virtual ICollection<TipoInfraestrServicio> TipoInfraestrServicios { get; set; }
    }
}
