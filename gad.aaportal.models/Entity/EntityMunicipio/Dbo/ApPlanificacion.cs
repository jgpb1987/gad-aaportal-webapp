using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ApPlanificacion
    {
        public int Id { get; set; }
        public int? Sector { get; set; }
        public string? CodParroquia { get; set; }
        public string? NomParroquia { get; set; }
        public int? FechaRecorrido { get; set; }
        public int? FechaCaducidad { get; set; }
    }
}
