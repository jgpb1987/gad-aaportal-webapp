using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrNotarium
    {
        public int CodigoNotaria { get; set; }
        public string? CodigoDivisionPolitica { get; set; }
        public string? NombreNotario { get; set; }
        public int? NotariaNumero { get; set; }
        public string? Estado { get; set; }

        public virtual DivPolAnt? CodigoDivisionPoliticaNavigation { get; set; }
    }
}
