using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RegistroBaja
    {
        public int Id { get; set; }
        public string? CodTitulo { get; set; }
        public double? Valor { get; set; }
        public string? NombreContribuyente { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? Comentario { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? CodigoIngreso { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
