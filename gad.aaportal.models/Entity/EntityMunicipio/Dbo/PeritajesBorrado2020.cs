using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class PeritajesBorrado2020
    {
        public int Id { get; set; }
        public string? ClaveCatastral { get; set; }
        public double? ValorTerreno { get; set; }
        public double? ValorEdificacion { get; set; }
        public double? ValorPropiedad { get; set; }
        public string? Usuario { get; set; }
        public string? Comentario { get; set; }
        public int? IdPeritaje { get; set; }
    }
}
