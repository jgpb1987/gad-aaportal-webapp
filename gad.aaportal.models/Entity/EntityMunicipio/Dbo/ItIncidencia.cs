using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ItIncidencia
    {
        public int? Idequipo { get; set; }
        public DateTime? FechaAviso { get; set; }
        public string? DescripcionIncidencia { get; set; }
        public string? QuienAvisa { get; set; }
        public DateTime? FechaDadoElServicio { get; set; }
        public string? DescripcionSolucion { get; set; }

        public virtual ItEquipo? IdequipoNavigation { get; set; }
    }
}
