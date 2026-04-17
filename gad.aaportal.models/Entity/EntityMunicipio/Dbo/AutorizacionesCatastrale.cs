using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class AutorizacionesCatastrale
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? NumeroDeTramite { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Civendedor { get; set; }
        public string? CiconstaEnCatastro { get; set; }
        public string? Cicomprador { get; set; }
        public double? ValorPropiedad { get; set; }
        public string? TipoTranspaso { get; set; }
        public string? Notaria { get; set; }
        public string? Notario { get; set; }
        public DateTime? FechaEscrituras { get; set; }
        public string? CantonEscrituras { get; set; }
        public double? AreaEscrituras { get; set; }
        public double? FrenteEscrituras { get; set; }
        public string? Observaciones { get; set; }
        public string? Fraccionamiento { get; set; }
        public string? ElavoradoPor { get; set; }
        public int Autonumerico { get; set; }
        public bool? Estado { get; set; }
        public string? TipoMedida { get; set; }

        public virtual Predio CodCatastralPredioNavigation { get; set; } = null!;
    }
}
