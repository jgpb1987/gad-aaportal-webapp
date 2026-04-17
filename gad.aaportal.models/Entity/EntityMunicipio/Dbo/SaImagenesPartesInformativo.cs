using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaImagenesPartesInformativo
    {
        public int IdImagenParte { get; set; }
        public int? IdParte { get; set; }
        public string? Imagen { get; set; }
        public string? Comentario { get; set; }
    }
}
