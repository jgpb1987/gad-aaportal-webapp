using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Premsa
    {
        public string? Titular { get; set; }
        public DateTime? Data { get; set; }
        public string? Diari { get; set; }
        public string? Resum { get; set; }
        public string? Àmbit { get; set; }
        public int? Id { get; set; }
        public string? Noticia { get; set; }
        public int ClavePrincipal { get; set; }
    }
}
