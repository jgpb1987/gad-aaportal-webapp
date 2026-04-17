using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Titulo
    {
        public int CodCreacionTitulo { get; set; }
        public string CodTitulo { get; set; } = null!;
        public string? DescripcionTitulo { get; set; }
        public int? Vencimiento { get; set; }
        public string? TipoVencimiento { get; set; }
        public string? EstadoTitulo { get; set; }
        public string? EstadoBloque { get; set; }
        public string? TitFacRegistro { get; set; }
        public string? Tributario { get; set; }
        public string? EstadoCostas { get; set; }
    }
}
