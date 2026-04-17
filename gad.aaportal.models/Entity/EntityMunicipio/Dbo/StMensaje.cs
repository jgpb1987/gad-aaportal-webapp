using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class StMensaje
    {
        public int NumeroDeTramite { get; set; }
        public int Secuencia { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public DateTime? FechaDeRegistro { get; set; }
        public string? FechaDelDocumento { get; set; }
        public string? IdDe { get; set; }
        public string? De { get; set; }
        public string? IdPara { get; set; }
        public string? Para { get; set; }
        public int Idmensaje { get; set; }
        public string? NumeroDeDocumento { get; set; }
        public int? NumeroDeHojas { get; set; }
        public string? Usuario { get; set; }
        public int? Plazo { get; set; }
        public string? SecuenciaDelFlujoAnterior { get; set; }
        public string? ParaMemo { get; set; }
        public string? CopiaMemo { get; set; }
        public string? AsuntoMemo { get; set; }

        public virtual StTramite NumeroDeTramiteNavigation { get; set; } = null!;
    }
}
