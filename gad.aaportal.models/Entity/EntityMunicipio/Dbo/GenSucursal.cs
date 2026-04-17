using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenSucursal
    {
        public string SucCodigo { get; set; } = null!;
        public string EmpCodigo { get; set; } = null!;
        public string SucNombre { get; set; } = null!;
        public int SucEstado { get; set; }
        public string? SucDireccion { get; set; }
        public string? SucCiudad { get; set; }
        public string? SucTelef1 { get; set; }
        public string? SucTelef2 { get; set; }
        public string? SucFax { get; set; }
        public int? SucAdmin { get; set; }
        public int? SucEstablecimiento { get; set; }
        public int? SucPuntoemision { get; set; }
    }
}
