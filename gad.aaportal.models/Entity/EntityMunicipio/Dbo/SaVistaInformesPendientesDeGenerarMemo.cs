using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SaVistaInformesPendientesDeGenerarMemo
    {
        public int Id { get; set; }
        public int? NroDenuncia { get; set; }
        public string? TipoDenuncia { get; set; }
        public string? DescripcionTipo { get; set; }
        public string? Motivo { get; set; }
        public DateTime? FechaDenuncia { get; set; }
        public string? DireccionDenuncia { get; set; }
        public int? NroInforme { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
