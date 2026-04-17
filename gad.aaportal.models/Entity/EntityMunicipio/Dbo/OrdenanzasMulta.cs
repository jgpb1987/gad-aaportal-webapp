using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class OrdenanzasMulta
    {
        public string CodOrdenanza { get; set; } = null!;
        public string? CodPadre { get; set; }
        public decimal? ArticuloOrdenanza { get; set; }
        public string? NombreOrdenanza { get; set; }
        public string? DescripcionOrdenanza { get; set; }
        public string? AreaEncargada { get; set; }
        public int? NumNotificaciones { get; set; }
        public int? PlazoNotificacion { get; set; }
        public string? CodTitulo { get; set; }
        public double? ValorOrdenanza { get; set; }
        public double? Valor1Ordenanza { get; set; }
        public string? UnidadOrdenanza { get; set; }
        public decimal? OpcionOrdenanza { get; set; }
        public bool? EstadoOrdenanza { get; set; }
    }
}
