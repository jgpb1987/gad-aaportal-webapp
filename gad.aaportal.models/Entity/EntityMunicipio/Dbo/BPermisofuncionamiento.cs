using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class BPermisofuncionamiento
    {
        public string Ruc { get; set; } = null!;
        public string NroLocal { get; set; } = null!;
        public string? FechaEmicion { get; set; }
        public string? Valor { get; set; }
        public string? Valor1 { get; set; }
        public string? Observaciones { get; set; }
        public string? NroPermiso { get; set; }
        public string Ano { get; set; } = null!;
        public string? Detalle { get; set; }
        public string? IdUsuario { get; set; }
        public string? TamanoAc { get; set; }
        public string? CodTesoreria { get; set; }
        public int? Id { get; set; }
    }
}
