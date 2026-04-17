using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelAt
    {
        public int? Id { get; set; }
        public string? Periodo { get; set; }
        public bool? Generado { get; set; }
        public string? NombreFichero { get; set; }
    }
}
