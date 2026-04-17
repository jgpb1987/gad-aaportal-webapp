using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlActividadesEconomica
    {
        public string Ruc { get; set; } = null!;
        public string CiPropietarioRepresentante { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public int? CodigoAct { get; set; }
        public string? Actividad { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? EmailLocal { get; set; }
        public int IdLocal { get; set; }
        public string? Nombre { get; set; }
        public string? TelefonoLocal { get; set; }
        public string? Nombres { get; set; }
    }
}
