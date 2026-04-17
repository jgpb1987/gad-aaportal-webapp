using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AeParametrosActividadesE
    {
        public string Id { get; set; } = null!;
        public string? Parametro { get; set; }
        public string? Descripcion { get; set; }
    }
}
