using gad.aaportal.commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.Declaracion
{
    public class ContribuyenteResumenDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;
    }
    public class ContribuyenteResumenDtoResult
    {
        public string Identificacion { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string TipoContribuyente { get; set; } = string.Empty;
        public string ActividadEconomica { get; set; } = string.Empty;
        public string InicioActividadEconomica { get; set; } = string.Empty;
        public string ContribuyenteEspecial { get; set; } = string.Empty;
        public string ObligadoLlevarContabilidad { get; set; } = string.Empty;
    }
    public class ContribuyenteResumenDataDtoResult:BaseResult
    {
        public ContribuyenteResumenDtoResult Data { get; set; } = null!;
    }
}
