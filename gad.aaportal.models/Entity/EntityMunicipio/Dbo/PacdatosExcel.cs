using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PacdatosExcel
    {
        public string? Id { get; set; }
        public string? Producto { get; set; }
        public string? Cpc { get; set; }
        public string? CuentaContableGrupo { get; set; }
        public string? Grupo { get; set; }
        public string? CuentaContableSubGrupo { get; set; }
        public string? SubGrupo { get; set; }
        public string? Um { get; set; }
        public string? Valor { get; set; }
        public string? DescripcionCompra { get; set; }
        public string? TipoDeProcedimiento { get; set; }
        public string? F12 { get; set; }
        public int Idok { get; set; }
    }
}
