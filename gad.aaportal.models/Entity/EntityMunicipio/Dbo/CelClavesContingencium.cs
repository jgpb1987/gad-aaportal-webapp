using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CelClavesContingencium
    {
        public int Id { get; set; }
        public string Clave { get; set; } = null!;
        public bool Usada { get; set; }
        public string? CodigoComprobante { get; set; }
    }
}
