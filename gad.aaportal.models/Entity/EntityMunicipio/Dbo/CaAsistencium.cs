using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CaAsistencium
    {
        public string Cedula { get; set; } = null!;
        public string? Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Ip { get; set; }
        public string? HostName { get; set; }
        public string? Usuario { get; set; }
    }
}
