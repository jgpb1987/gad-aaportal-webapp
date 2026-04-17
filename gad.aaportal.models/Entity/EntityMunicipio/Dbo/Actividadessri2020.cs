using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Actividadessri2020
    {
        public string Ruc { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string? Descripcion { get; set; }
        public string? Obligado { get; set; }
        public string? Actividad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Canton { get; set; }
        public string? Parroquia { get; set; }
        public DateTime? FechaInicioAct { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
