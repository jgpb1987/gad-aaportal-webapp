using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class NcPrediosPagosMej
    {
        public int IdPredioPag { get; set; }
        public int? CodigoIngreso { get; set; }
        public string? CedulaCiudadano { get; set; }
        public string? Ciudadano { get; set; }
        public double? ValorMej { get; set; }
        public string? Sistema { get; set; }
        public string? ClaveCatastral { get; set; }
        public string? CodigoObra { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Comentario { get; set; }
        public string? UsuarioIng { get; set; }
    }
}
