using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.models.Entity.Log
{
    public partial class SolicitudRespuesta
    {
        public long Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodigoUsuario { get; set; } = null!;
        public long Secuencial { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public DateTime FechaHoraEnvio { get; set; }
        public DateTime FechaHoraRespuesta { get; set; }
        public string Proveedor { get; set; } = null!;
        public string Metodo { get; set; } = null!;
        public string TramaEnvio { get; set; } = null!;
        public string TramaRespuesta { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public bool Exito { get; set; }
    }
}
