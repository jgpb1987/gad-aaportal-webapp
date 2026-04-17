using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Sucursale
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string NroSucursal { get; set; } = null!;
        public string? NombreDelLocal { get; set; }
        public string? Direccion { get; set; }
        public string? Nro { get; set; }
        public string? Actividad { get; set; }
        public string? Telefono { get; set; }
        public double? Capital { get; set; }
        public bool? EnActividad { get; set; }
        public double? AreaSucursal { get; set; }
        public string? ClaveCatastral { get; set; }

        public virtual Local Local { get; set; } = null!;
    }
}
