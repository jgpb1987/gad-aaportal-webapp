using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StMaquinarium
    {
        public int IdMaquinaria { get; set; }
        public string? NombreMaquinaria { get; set; }
        public double? CostoHora { get; set; }
    }
}
