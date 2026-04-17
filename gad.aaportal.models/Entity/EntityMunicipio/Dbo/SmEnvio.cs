using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class SmEnvio
    {
        public int? CodigoObra { get; set; }
        public string? CodigoObraAnterior { get; set; }
        public string? EstadoObra { get; set; }
        public int? CodigoObraMadre { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string? DependenciaEnviada { get; set; }
        public string? DependenciaQueEnvia { get; set; }
        public string? Usuario { get; set; }
    }
}
