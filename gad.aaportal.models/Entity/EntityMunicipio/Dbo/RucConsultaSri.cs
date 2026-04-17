using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RucConsultaSri
    {
        public int Id { get; set; }
        public string? NumeroRuc { get; set; }
        public string? PersonaSociedad { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreFantasiaComercial { get; set; }
        public string? Obligado { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public DateTime? FechaReInicioActividades { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public DateTime? FechaSuspencionDefinitiva { get; set; }
        public string? ActividadEconomicaPrincipal { get; set; }
        public string? EstadoPersonaNatural { get; set; }
        public string? EstadoSociedad { get; set; }
        public string? TipoContribuyente { get; set; }
        public string? ClaseContribuyente { get; set; }
        public string? DireccionCorta { get; set; }
        public string? Email { get; set; }
        public string? TelefonoDomicilio { get; set; }
        public string? TelefonoTrabajo { get; set; }
        public DateTime? FechaConsulta { get; set; }
    }
}
