using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TePrestamoInstitucionFinanciera
    {
        public int IdInstitucion { get; set; }
        public string? Institucion { get; set; }
        public string? TipoDeduccion { get; set; }
    }
}
