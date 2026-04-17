using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TmpFaltaArrendamiento
    {
        public string Ruc { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string? NroLocal { get; set; }
        public string? Personeria { get; set; }
        public int? CapitalSocial { get; set; }
        public int? Mes { get; set; }
        public string? Año { get; set; }
    }
}
