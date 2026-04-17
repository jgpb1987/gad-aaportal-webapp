using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VistaPredio
    {
        public string CodCatastralPredio { get; set; } = null!;
        public string? CallePredio { get; set; }
        public string? NumeroPredio { get; set; }
        public string? NombrePredio { get; set; }
        public string? CiuCedula { get; set; }
        public string? PropietarioApellidos { get; set; }
        public string? PropietarioNombres { get; set; }
        public string? CedulaRepresLegPredio { get; set; }
        public string? RepresentanteLegalApellidos { get; set; }
        public string? RepresentanteLegalNombres { get; set; }
        public string? PropAnteriorPredio { get; set; }
        public string? TipoPredio { get; set; }
        public string? NombreUbicacion { get; set; }
        public string? ClaveMigrada { get; set; }
        public string? CodAnteriorPredio { get; set; }
    }
}
