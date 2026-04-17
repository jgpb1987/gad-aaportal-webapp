using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelConfiguracionesDirectorio
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
