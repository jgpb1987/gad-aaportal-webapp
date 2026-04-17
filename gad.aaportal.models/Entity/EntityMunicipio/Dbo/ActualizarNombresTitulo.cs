using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class ActualizarNombresTitulo
    {
        public int CodIngreso { get; set; }
        public string? Nombre { get; set; }
        public string CodClienteIngreso { get; set; } = null!;
        public string? NombreCompleto { get; set; }
    }
}
