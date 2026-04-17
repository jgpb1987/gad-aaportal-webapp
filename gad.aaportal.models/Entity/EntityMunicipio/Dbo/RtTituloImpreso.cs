using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RtTituloImpreso
    {
        public int CodigoTituloImpreso { get; set; }
        public int? CodDatosIngreso { get; set; }
        public DateTime? FechaTituloImpreso { get; set; }
        public string? UsuarioImprime { get; set; }
        public int? NumeroTituloImpreso { get; set; }
        public double? InteresTituloImpreso { get; set; }
        public double? RecargoTituloImpreso { get; set; }
        public string? Estado { get; set; }
    }
}
