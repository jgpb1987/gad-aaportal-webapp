using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StDenunciasAmbiental
    {
        public int NumeroDeTramite { get; set; }
        public string? NombreDenunciante { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? DireccionDomCiudadano { get; set; }
        public string? TelefonoCiudadano { get; set; }
        public string? Celular { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? CirepresentanteLegal { get; set; }
        public string? RepresentanteLegal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? ElementoContaminado { get; set; }
        public string? DescripcionDenuncia { get; set; }
        public DateTime? FechaDenuncia { get; set; }
        public string? CalificacionDenuncia { get; set; }
        public string? AprobadoJefeUga { get; set; }
        public string? AprobadoComisario { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
