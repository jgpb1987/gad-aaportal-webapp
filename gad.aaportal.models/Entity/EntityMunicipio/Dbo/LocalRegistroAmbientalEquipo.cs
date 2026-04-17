using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class LocalRegistroAmbientalEquipo
    {
        public int IdEquipos { get; set; }
        public string? Equipo { get; set; }
        public string? Cantidad { get; set; }
        public string? Potencia { get; set; }
        public string? Caracteristicas { get; set; }
        public int? IdLocal { get; set; }
    }
}
