using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class CwCiudadanosActualizar
    {
        public string Cedula { get; set; } = null!;
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? Parroquia { get; set; }
        public string? CallePrincipal { get; set; }
        public string? CalleSecundaria { get; set; }
        public string? Referencia { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
