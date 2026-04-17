using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SiCalculoImpuesto
    {
        public int IdCalculo { get; set; }
        public int? IdCompra { get; set; }
        public double? ValorImpuesto { get; set; }
        public int? IdTipoImpuesto { get; set; }
        public double? AvaluoCalculo { get; set; }
        public string? Usuario { get; set; }
        public int? CodIngreso { get; set; }
        public double? ValorAlcabala { get; set; }
        public double? ValorConstruccionEscolares { get; set; }
        public double? DescuentoTerceraEdad { get; set; }
        public double? DescuentoAnios { get; set; }
        public double? UtilidadBruta { get; set; }
        public double? ValorCincoAniosTrans { get; set; }
        public double? DesvMonetaria { get; set; }
        public double? PlusvaliaExedente { get; set; }
        public double? BaseImponible { get; set; }
        public int? TotalAnios { get; set; }
        public double? PorcentajeDesv { get; set; }

        public virtual SiDatosCompra? IdCompraNavigation { get; set; }
    }
}
