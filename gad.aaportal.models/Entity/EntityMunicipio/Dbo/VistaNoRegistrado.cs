using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaNoRegistrado
    {
        public string? NumeroRuc { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreComercial { get; set; }
        public string? EstadoDelContribuyente { get; set; }
        public string? ClaseDelContribuyente { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaSuspenciónDefinitiva { get; set; }
        public string? Obligadosallevarcontabilidad { get; set; }
        public string? Tipodecontribuyente { get; set; }
        public double? Numerodeestablecimientos { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Interseccion { get; set; }
        public string? Actividadeconomica { get; set; }
    }
}
