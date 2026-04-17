using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaImgenesInforme
    {
        public int IdImagen { get; set; }
        public int? IdInforme { get; set; }
        public string? DireccionImagen { get; set; }
        public string? Comentario { get; set; }
    }
}
