using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaActividadesEconomicasDeben
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string? Nro { get; set; }
        public string? Personeria { get; set; }
        public string? RazonSocial { get; set; }
        public string? Actividad { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? NombreDelLocal { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        public byte EnActividad { get; set; }
        public string? ClaveCatastralPredio { get; set; }
        public int? Aniopago { get; set; }
        public DateTime? FechaEmicion { get; set; }
    }
}
