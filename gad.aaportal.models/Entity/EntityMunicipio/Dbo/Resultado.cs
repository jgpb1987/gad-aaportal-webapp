using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Resultado
    {
        public int IdVehiculo { get; set; }
        public string? Placas { get; set; }
        public string? Color { get; set; }
        public string? Matricula { get; set; }
    }
}
