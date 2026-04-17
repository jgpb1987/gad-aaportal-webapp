using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Adicionaltacho
    {
        public string? CedIdentCiudadano { get; set; }
        public DateTime? FechaAemitir { get; set; }
        public double? Valor { get; set; }
        public string? Comentario { get; set; }
        public int? CodigoIngresoArentas { get; set; }
        public int? Ntach { get; set; }
        public string? Sector { get; set; }
        public string? Cuenta { get; set; }

        public virtual Ciudadano? CedIdentCiudadanoNavigation { get; set; }
    }
}
