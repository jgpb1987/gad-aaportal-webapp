using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ParametrosInstitucionale
    {
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string? NombreComercial { get; set; }
        public string DireccionMatriz { get; set; } = null!;
        public string? DireccionEstablecimiento { get; set; }
        public string CodigoEstablecimiento { get; set; } = null!;
        public string CodigoPuntoEmision { get; set; } = null!;
        public string? ContribuyenteEspecial { get; set; }
        public bool LlevaContabilidad { get; set; }
        public string? Logo { get; set; }
        public int TipoAmbienteCodigo { get; set; }
        public int TipoEmisionCodigo { get; set; }
        public int TiempoEspera { get; set; }
        public string? FirmaElectronica { get; set; }
        public string? ClaveFirmaElectronica { get; set; }
        public string? EjercicioFiscal { get; set; }
    }
}
