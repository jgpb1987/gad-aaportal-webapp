using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class UsActividade
    {
        public string CodUsoSuelo { get; set; } = null!;
        public string? CodPadreUsoSuelo { get; set; }
        public string? DescripcionUsoSuelo { get; set; }
        public string? EstadoUsoSuelo { get; set; }
    }
}
