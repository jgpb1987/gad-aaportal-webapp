using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SlDocumentosAdjunto
    {
        public int Id { get; set; }
        public string? Ruc { get; set; }
        public int? IdMov { get; set; }
        public string? Ruta { get; set; }
    }
}
