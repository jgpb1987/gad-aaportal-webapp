using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Declaracion
{
    public partial class ContribuyenteDeclaracionPagoEstablecimiento
    {
        public long Id { get; set; }
        public long IdContribuyenteDeclaracion { get; set; }
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public decimal Porcentaje { get; set; }
        public decimal Valor { get; set; }
        public bool AplicaPago { get; set; }
        public bool Estado { get; set; }

        public virtual ContribuyenteDeclaracion IdContribuyenteDeclaracionNavigation { get; set; } = null!;
    }
}
