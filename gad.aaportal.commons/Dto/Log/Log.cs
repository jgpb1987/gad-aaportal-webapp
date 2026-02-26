using gad.aaportal.commons.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.Log
{
    public class LogParam
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string CodigoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public long Secuencial { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string NumeroDocumento { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public DateTime FechaHoraEnvio { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public DateTime FechaHoraRespuesta { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string Proveedor { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string Metodo { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string TramaEnvio { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string TramaRespuesta { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string Codigo { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public string Mensaje { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio para realizar la transacción")]
        public bool Exito { get; set; }
    }
    public class LogResult : BaseResult
    {
        public long IdInsercion { get; set; }
    }
}
