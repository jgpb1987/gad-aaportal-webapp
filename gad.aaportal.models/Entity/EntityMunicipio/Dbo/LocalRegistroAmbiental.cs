using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalRegistroAmbiental
    {
        public string? Ruc { get; set; }
        public int? NroLocal { get; set; }
        public string? DescripcionActividad { get; set; }
        public int? Administrativos { get; set; }
        public int? Produccion { get; set; }
        public string? HorasLaborables { get; set; }
        public string? Luz { get; set; }
        public string? Agua { get; set; }
        public string? Combustible { get; set; }
        public string? Otros { get; set; }
        public string? Nodomesticos { get; set; }
        public string? Peligrosos { get; set; }
        public bool? Certificado { get; set; }
        public bool? Registro { get; set; }
        public bool? LicenciaDia { get; set; }
        public bool? LicenciaEsia { get; set; }
        public int IdLocal { get; set; }
        public string? Tipo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
        public int? NroRegistro { get; set; }
        public string? TipoEstablecimiento { get; set; }
        public string? ObservacionesGenerales { get; set; }
        public string? TurnosDeTrabajo { get; set; }
        public string? DiasMes { get; set; }
    }
}
