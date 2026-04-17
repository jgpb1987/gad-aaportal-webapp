using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItEquipo
    {
        public int Id { get; set; }
        public string? TipoEquipo { get; set; }
        public string? CodigoActivo { get; set; }
        public string? CedulaCustodio { get; set; }
        public DateTime? FechaAdquicicion { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Ubicacion { get; set; }
        public string? Serie { get; set; }
        public string? Ip { get; set; }
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? GarantiaHastaCuando { get; set; }
        public DateTime? FechaActualizacionDatos { get; set; }
        public int? IdempresaProveedora { get; set; }

        public virtual ItEmpresaProveedora? IdempresaProveedoraNavigation { get; set; }
        public virtual ItEquiposTipo? TipoEquipoNavigation { get; set; }
        public virtual ItComputadora? ItComputadora { get; set; }
        public virtual ItImpresora? ItImpresora { get; set; }
        public virtual ItSwich? ItSwich { get; set; }
    }
}
