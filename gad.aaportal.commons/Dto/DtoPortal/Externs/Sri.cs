using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.Externs
{
    public class InfoFechasContribuyente
    {
        public string FechaInicioActividades { get; set; } = null!;
        public string FechaCese { get; set; } = null!;
        public string FechaReinicioActividades { get; set; } = null!;
        public string FechaActualizacion { get; set; } = null!;
    }

    public class InfoRucResult
    {
        public string NumeroRuc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string EstadoContribuyenteRuc { get; set; } = null!;
        public string ActividadEconomicaPrincipal { get; set; } = null!;
        public string TipoContribuyente { get; set; } = null!;
        public string Regimen { get; set; } = null!;
        public string? Categoria { get; set; }
        public string ObligadoLlevarContabilidad { get; set; } = null!;
        public string AgenteRetencion { get; set; } = null!;
        public string ContribuyenteEspecial { get; set; } = null!;
        public InfoFechasContribuyente InformacionFechasContribuyente { get; set; } = null!;
        public object? RepresentantesLegales { get; set; }
        public object? MotivoCancelacionSuspension { get; set; }
        public string ContribuyenteFantasma { get; set; } = null!;
        public string TransaccionesInexistente { get; set; } = null!;
    }
    public class InfoEstablecimientoResult
    {
        public string NombreFantasiaComercial { get; set; } = null!;
        public string TipoEstablecimiento { get; set; } = null!;
        public string DireccionCompleta { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string NumeroEstablecimiento { get; set; } = null!;
        public string Matriz { get; set; } = null!;
    }
}
