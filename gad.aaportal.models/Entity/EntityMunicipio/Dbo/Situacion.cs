using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Situacion
    {
        public int CodSituacion { get; set; }
        public string? DescripcionSituacion { get; set; }
        public string? Estado { get; set; }
    }
}
