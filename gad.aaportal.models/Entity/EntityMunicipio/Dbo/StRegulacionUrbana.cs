using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StRegulacionUrbana
    {
        public int NumeroDeTramite { get; set; }
        public string? TipoCertificado { get; set; }
        public string? Superficie { get; set; }
        public string? Frente { get; set; }
        public string? LoteNumero { get; set; }
        public string? DetalleProyecto { get; set; }
        public string? DescripcionOtrosFines { get; set; }
        public string? RetiroFrontal { get; set; }
        public string? RetiroLateral { get; set; }
        public string? RetiroFondo { get; set; }
        public string? AdosamientoLateral { get; set; }
        public string? AdosamientoPosterior { get; set; }
        public string? AdosamientoLindero { get; set; }
        public string? Zonificacion { get; set; }
        public string? RedElectrica { get; set; }
        public string? RedElectricaDescripcion { get; set; }
        public string? RedElectricaTipo { get; set; }
        public string? RedElectricaPisos { get; set; }
        public string? RedElectricaAltura { get; set; }
        public string? DisponibilidadTotalmente { get; set; }
        public string? DisponibilidadParcialmente { get; set; }
        public string? DisponibilidadCerramiento { get; set; }
        public string? DisponibilidadLineaDeFabrica { get; set; }
        public string? InformesAdicionales { get; set; }
        public byte[]? ImagenCroquis { get; set; }
        public string? EntreCalles { get; set; }
        public DateTime? FechaDeImpresion { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
