using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class TrasDominio
    {
        public int CodTrasDominio { get; set; }
        public string? DescripcionTrasDominio { get; set; }
        public string? EstadoTrasDominio { get; set; }
        public string? TraDoCodigoFicha { get; set; }
        public string? TraDoTipo { get; set; }
    }
}
