using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CiiuBombero
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Pequenos { get; set; }
        public string? Medianos { get; set; }
        public string? Grandes { get; set; }
        public string? Sgrande { get; set; }
    }
}
