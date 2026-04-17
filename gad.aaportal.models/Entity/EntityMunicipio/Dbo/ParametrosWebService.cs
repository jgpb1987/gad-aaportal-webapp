using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ParametrosWebService
    {
        public int IdParametro { get; set; }
        public int? IdDesdeSiguienteConsulta { get; set; }
        public int? CantidadDiaria { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Mensaje { get; set; }
        public int? IdDesdeSiguienteSri { get; set; }
    }
}
