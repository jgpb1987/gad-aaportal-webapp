using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaPacReporteProductosComprado
    {
        public string CuentaContableGrupo { get; set; } = null!;
        public string Grupo { get; set; } = null!;
        public string CuentaContableSubGrupo { get; set; } = null!;
        public string SubGrupo { get; set; } = null!;
        public string? Cpc { get; set; }
        public string Producto { get; set; } = null!;
        public double ValorProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? ValorCompra { get; set; }
        public int? Anio { get; set; }
        public int IdDependencia { get; set; }
        public string? Dependencia { get; set; }
        public int? IdPacDescripcionCompra { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoCompra { get; set; }
    }
}
