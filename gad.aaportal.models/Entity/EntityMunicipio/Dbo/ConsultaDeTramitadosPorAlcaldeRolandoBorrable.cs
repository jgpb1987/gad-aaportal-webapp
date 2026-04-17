using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ConsultaDeTramitadosPorAlcaldeRolandoBorrable
    {
        public int NumeroDeTramite { get; set; }
        public int Secuencia { get; set; }
        public string? Para { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public string? De { get; set; }
        public int Idmensaje { get; set; }
        public string? AsuntoMemo { get; set; }
    }
}
