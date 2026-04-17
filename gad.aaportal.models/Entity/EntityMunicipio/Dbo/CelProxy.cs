using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelProxy
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int? Puerto { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
        public string Wsproduccion { get; set; } = null!;
        public string Wspruebas { get; set; } = null!;
    }
}
