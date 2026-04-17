using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmEmisione
    {
        public int CodigoEmision { get; set; }
        public int? IdObraPredio { get; set; }
        public int? CodigoIngreso { get; set; }
        public string? CedIdentCiudadano { get; set; }
        public string? Ciudadano { get; set; }
        public string? Direccion { get; set; }
        public double? ValorMejora { get; set; }
        public string? Estado { get; set; }
        public string? Sistema { get; set; }
        public string? CuotaAnio { get; set; }
        public string? CuotaMes { get; set; }
        public string? TipoDeObra { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CodigoObraAnterior { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? CodTitulo { get; set; }
        public string? NumeroMedidor { get; set; }
        public string? Comentario { get; set; }
        public double? AliAdoquinado { get; set; }
        public double? AliAceras { get; set; }
        public double? AliAlcantarillado { get; set; }
        public double? AliObrasAgua { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? CodigoIngresoDivision { get; set; }
        public string? TipoIngresoDivisiones { get; set; }
    }
}
