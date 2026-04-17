using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApContratosNuevo
    {
        public int CodIngreso { get; set; }
        public string NroContrato { get; set; } = null!;
        public string? Clave { get; set; }
        public string? Tarifa { get; set; }
        public string? TipoPago { get; set; }
        public int? Cuotas { get; set; }
        public string? IngresadoPor { get; set; }
        public double? Valor { get; set; }
        public int? CodIngreso1 { get; set; }
        public string? FechaCreacion { get; set; }
        public string? CedulaCiudadano { get; set; }
        public string? ReferenciaDireccion { get; set; }

        public virtual Ciudadano? CedulaCiudadanoNavigation { get; set; }
    }
}
