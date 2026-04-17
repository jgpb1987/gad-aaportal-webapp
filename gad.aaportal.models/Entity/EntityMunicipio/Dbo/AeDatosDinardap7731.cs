using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeDatosDinardap7731
    {
        public int CodigoDinardap { get; set; }
        public string NumeroEstablecimiento { get; set; } = null!;
        public string TipoEstablecimiento { get; set; } = null!;
        public string? EstadoEstablecimiento { get; set; }
        public string? NombreFantasiaComercial { get; set; }
        public string? Calle { get; set; }
        public string? Interseccion { get; set; }
        public string? ReferenciaUbicacion { get; set; }
        public string? UbicacionGeografica { get; set; }
        public string? Barrio { get; set; }

        public virtual AeDatosDinardap CodigoDinardapNavigation { get; set; } = null!;
    }
}
