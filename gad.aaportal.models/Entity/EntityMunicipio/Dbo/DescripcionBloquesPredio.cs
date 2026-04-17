using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class DescripcionBloquesPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public int NumeroBloquePredio { get; set; }
        public int? EdadConst { get; set; }
        public int? Reparacion { get; set; }
        public string? _01estructura { get; set; }
        public string? _01estadoDeConservación { get; set; }
        public string? _01númeroDePisos { get; set; }
        public string? _02columnasYPilastras { get; set; }
        public string? _02vigasYCadenas { get; set; }
        public string? _02entrePisos { get; set; }
        public string? _02paredes { get; set; }
        public string? _02escalera { get; set; }
        public string? _02cubierta { get; set; }
        public string? _03revestimientoDePisos { get; set; }
        public string? _03revestimientoInterior { get; set; }
        public string? _03revestimientoExterior { get; set; }
        public string? _03revestimientoEscalera { get; set; }
        public string? _03tumbados { get; set; }
        public string? _03cubierta { get; set; }
        public string? _03puertas { get; set; }
        public string? _03ventanas { get; set; }
        public string? _03cubreVentanas { get; set; }
        public string? _03closets { get; set; }
        public string? _04sanitarias { get; set; }
        public string? _04baños { get; set; }
        public string? _04eléctricas { get; set; }
    }
}
