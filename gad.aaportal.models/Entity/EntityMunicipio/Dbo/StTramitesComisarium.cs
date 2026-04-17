using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramitesComisarium
    {
        public int NumeroDeTramite { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? TipoActividad { get; set; }
        public string? Parroquia { get; set; }
        public string? Direccion { get; set; }
        public string? AreaOcupacion { get; set; }
        public string? Duracion { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta { get; set; }
        public string? MesDesde { get; set; }
        public string? MesHasta { get; set; }
        public string? Anio { get; set; }
        public string? HoraDesde { get; set; }
        public string? HoraHasta { get; set; }
        public string? ValorPermiso { get; set; }
        public string? NumeroDeUnidades { get; set; }
        public bool? Expoferia { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
