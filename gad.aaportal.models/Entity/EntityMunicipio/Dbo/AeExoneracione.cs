using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeExoneracione
    {
        public int IdExoneracion { get; set; }
        public string? Descripcion { get; set; }
        public string? ExoneracionPatente { get; set; }
        public string? ExoneracionIat { get; set; }
        public string? EstadoDeclaracion { get; set; }
    }
}
