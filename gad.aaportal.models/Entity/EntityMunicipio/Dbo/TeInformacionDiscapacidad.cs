using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TeInformacionDiscapacidad
    {
        public int Id { get; set; }
        public string? CiBeneficiario { get; set; }
        public int? IdExoneracionesPersona { get; set; }
        public double? PorcentajeDiscapacidad { get; set; }
        public string? Parentesco { get; set; }
        public string? TipoDiscapacidad { get; set; }
        public string? Condicion { get; set; }
        public string? ClaveCatastral { get; set; }

        public virtual TeExoneracionesPersona? IdExoneracionesPersonaNavigation { get; set; }
    }
}
