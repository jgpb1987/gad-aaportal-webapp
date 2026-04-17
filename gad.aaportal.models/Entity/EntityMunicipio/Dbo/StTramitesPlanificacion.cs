using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StTramitesPlanificacion
    {
        public int NumeroDeTramite { get; set; }
        public string? AreaOcupacionCalle { get; set; }
        public string? TiempoOcupacionCalle { get; set; }
        public string? AreaOcupacionAcera { get; set; }
        public string? TiempoOcupacionAcera { get; set; }
        public string? HoraTurno { get; set; }
        public string? FechaTurno { get; set; }
        public string? AreaOcupacionCerramiento { get; set; }
        public string? TasaCerramientoProvisional { get; set; }
        public string? RangoCerramiento { get; set; }
        public string? ValorCerramiento { get; set; }
        public string? AreaExcedente { get; set; }
        public string? AvaluoMetro { get; set; }
        public string? NumeroLotes { get; set; }
        public string? AreaFraccionamiento { get; set; }
        public string? OrdenanzaFraccionamiento { get; set; }
        public string? TasaFraccionamiento { get; set; }
        public string? Actualizacion { get; set; }
        public string? Ampliacion { get; set; }
        public string? Modificacion { get; set; }
        public string? AvaluoConstruccion { get; set; }
        public string? FondoGarantia { get; set; }
        public string? MontoLegalizacion { get; set; }
        public string? FondoGarantiaCalculado { get; set; }
        public string? AprobacionPlanosCalculado { get; set; }
        public string? TasaAreaVerdeFraccionamiento { get; set; }
        public string? Profesional { get; set; }
        public string? EstadoCarpeta { get; set; }
        public string? AprobacionFraccionamientoCalculado { get; set; }
        public string? AprobacionAreaVerdeCalculado { get; set; }
        public string? ExcedenteCalculado { get; set; }
        public string? ValorVariosTrabajos { get; set; }
        public string? TitulosAdicionalesPlanimetrias { get; set; }
        public string? CedulaBeneficiario { get; set; }
        public string? AreaConstruccion { get; set; }
        /// <summary>
        /// Declaratoria Propiedad Horizontal Locales Comerciales
        /// </summary>
        public string? AreaAbierta { get; set; }
        /// <summary>
        /// Declaratoria Propiedad Horizontal Locales Comerciales
        /// </summary>
        public string? AreaLotes { get; set; }
        public int? NumeroDeArchivo { get; set; }
        public string? AreaLibre { get; set; }
        public string? LocalesComerciales { get; set; }
        public string? ConjuntosHabitacionales { get; set; }
        public string? FraccionSobreExcedente { get; set; }
        public string? PorcentajeFondoRural { get; set; }
        public string? AreaVerde { get; set; }
        public string? TasaMunicipalExcedentes { get; set; }
        public string? TasaAdministrativaMostrenco { get; set; }
        public string? TasaTitularizacionMostrenco { get; set; }
        public string? AvaluoTerreno { get; set; }
        public bool? PorColocacion { get; set; }
        public double? M2 { get; set; }
        public int? IdTipoConstruccion { get; set; }
        public bool? PorFondoGarantia { get; set; }
        public double? AprobacionLegalizacion { get; set; }
        public double? M2legalizacion { get; set; }
        public double? IdTipoConstruccionLegalizacion { get; set; }
        public string? NroTramiteInicial { get; set; }
        public string? CiProfesional { get; set; }
        public string? SancionLegalizacionPlanos { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
