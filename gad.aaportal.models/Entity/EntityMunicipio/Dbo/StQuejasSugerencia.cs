using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StQuejasSugerencia
    {
        public int? NumeroDeTramite { get; set; }
        public int Id { get; set; }
        public string? CallePrincipal { get; set; }
        public string? CalleSecundaria { get; set; }
        public string? Barrio { get; set; }
        public string? NumeroDeCasa { get; set; }
        public double? CoordenadasX { get; set; }
        public double? CoordenadasY { get; set; }
        public string? Referencias { get; set; }
        public string? Email { get; set; }
        public string? NumPredio { get; set; }
        public string? Telefono { get; set; }
        public string? Asunto { get; set; }

        public virtual StTramite? NumeroDeTramiteNavigation { get; set; }
    }
}
