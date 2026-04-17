using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRegistroAmbientalNoAutomatizado
    {
        public int IdUnico { get; set; }
        public int? NumeroDeRegistro { get; set; }
        public int NumeroDeTramite { get; set; }
        public string? CodigoCiiu { get; set; }
        public string? Representante { get; set; }
        public string? RazonSocial { get; set; }
        public string? Ruc { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? NoDomesticos { get; set; }
        public string? Peligrosos { get; set; }
        public string? Observaciones { get; set; }
        public string? Residuos { get; set; }
        public string? Inspeccion { get; set; }
        public string? ObservacionesInspeccion { get; set; }
        public string? FechaProvisional { get; set; }
        public string? FechaDefinitivo { get; set; }
        public string? FechaRenovacion { get; set; }
        public string? LocalRuc { get; set; }
        public string? CiudadanoCedula { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
