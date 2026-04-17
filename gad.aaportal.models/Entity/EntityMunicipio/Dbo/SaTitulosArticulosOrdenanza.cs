using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaTitulosArticulosOrdenanza
    {
        public int IdTitulosArticulos { get; set; }
        public int? IdOrdenanza { get; set; }
        public string? TituloArticulos { get; set; }
    }
}
