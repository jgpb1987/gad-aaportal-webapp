using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Local
    {
        public Local()
        {
            LocalAnuals = new HashSet<LocalAnual>();
        }

        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string? Nro { get; set; }
        public string? Personeria { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public string? Actividad { get; set; }
        public string CodigoCiiu { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? NombreDelLocal { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? CirepresentanteLegal { get; set; }
        public DateTime? FechaConstitucion { get; set; }
        public byte? NroSocios { get; set; }
        public double? CapitalSocial { get; set; }
        public double? Patrimonio { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public double? PorcentajeAccionarioSectorPublico { get; set; }
        public byte? EmpresaPublica { get; set; }
        public byte EnActividad { get; set; }
        public byte Liquidado { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public byte? LocalArrendado { get; set; }
        public byte? UbicadoMercado { get; set; }
        public string? ClaveCatastralPredio { get; set; }
        public string? Calidad { get; set; }
        public string? NroCalificacionArtesano { get; set; }
        public double? EjercicioEconomicoAnterior { get; set; }
        public string? IdUsuario { get; set; }
        public byte? PersonalAdministrativo { get; set; }
        public byte? PersonalProduccion { get; set; }
        public byte? TurnosTrabajo { get; set; }
        public byte? TrabajoHorasDiarias { get; set; }
        public byte? TrabajoDiasPorSemana { get; set; }
        public DateTime? FechaCertificadoRegistroMedioAmbiente { get; set; }
        public bool? ActividadTuristica { get; set; }
        public bool? Kiosko { get; set; }
        public string? Observacion { get; set; }
        public byte? TransporteLiviano { get; set; }
        public byte? TransportePesado { get; set; }
        public byte? Rise { get; set; }
        /// <summary>
        /// AE sin competar los datos
        /// </summary>
        public short? DatosCompletos { get; set; }
        public string? TipoTransporte { get; set; }
        public string? RepresentanteLegal { get; set; }

        public virtual Ciudadano? CirepresentanteLegalNavigation { get; set; }
        public virtual Ciiu CodigoCiiuNavigation { get; set; } = null!;
        public virtual LocalMercado? LocalMercado { get; set; }
        public virtual ICollection<LocalAnual> LocalAnuals { get; set; }
    }
}
