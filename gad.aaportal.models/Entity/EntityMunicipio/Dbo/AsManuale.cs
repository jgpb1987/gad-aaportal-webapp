using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AsManuale
    {
        public int IdSistema { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Version { get; set; } = null!;
        public bool? Visible { get; set; }
        public int? IdCategoria { get; set; }
        public string? Path { get; set; }
    }
}
