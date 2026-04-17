using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class RteNotificadore
    {
        public int CodigoNotificador { get; set; }
        public string? CiNotificador { get; set; }
        public string? CodIdentificacionNotificador { get; set; }
        public string? NombreNotificador { get; set; }
        public string? EmpresaNotificadora { get; set; }
        public string? EstadoNotificador { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
