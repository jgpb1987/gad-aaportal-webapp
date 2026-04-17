using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RegistroMovimientosCiudadano
    {
        public string? Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? CedIdentNew { get; set; }
        public string? CedIdentOld { get; set; }
        public string? ApellidosOld { get; set; }
        public string? NombresOld { get; set; }
        public string? Mas { get; set; }
    }
}
