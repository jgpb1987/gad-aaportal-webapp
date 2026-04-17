using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeRecargoSolarInfo
    {
        public int IdRecargoInfo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? TipoDestino { get; set; }
        public int? IdExoneracionPersona { get; set; }

        public virtual TeExoneracionesPersona? IdExoneracionPersonaNavigation { get; set; }
    }
}
