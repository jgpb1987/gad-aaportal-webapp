using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ConeccionesBdd
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cadena { get; set; }
    }
}
