using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaTitulosDeCreditoDeActividadesEconomica
    {
        public string Cedula { get; set; } = null!;
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Anio { get; set; }
        public DateTime? FechaPago { get; set; }
        public int CodIngreso { get; set; }
        public double? Valor { get; set; }
        public string? TelefonoCiudadano { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CodAdoquinado { get; set; }
        public double? Intereses { get; set; }
    }
}
