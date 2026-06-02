using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.DtoPortal.Declaracion
{
    public class ContribuyenteDtoParam
    {
        public string Identificacion { get; set; } = null!;
    }
    public class ContribuyenteEstablecimientoPago
    {
        public string Provincia { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public decimal BaseImponible { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Valor { get; set; }
        public bool AplicaPago { get; set; }
        public bool EsMunicipioBase { get; set; }
    }
    public class PeriodoDeclaracionDtoResult
    {
        public int AnioEjercicioFiscal { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorriente { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal PasivoContingente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal CostosGastos { get; set; }
    }
    public class PeriodoDeclaracionListResult : BaseResult
    {
        public List<PeriodoDeclaracionDtoResult> PeriodosDeclaracion { get; set; } = null!;
        public List<ContribuyenteEstablecimientoPago> Establecimientos { get; set; } = null!;
    }
    public class PeriodoDeclaracionDataResult : BaseResult
    {
        public PeriodoDeclaracionListResult Data { get; set; } = new();
    }
    public class IniciarDeclaracionDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;

        [Range(2000, 2100, ErrorMessage = "Debe seleccionar un año de declaración válido.")]
        public int AnioDeclaracion { get; set; }

        public int EjercicioFiscal { get; set; }
    }
    public class IniciarDeclaracionDtoResult
    {
        public string Identificacion { get; set; } = string.Empty;
        public int AnioDeclaracion { get; set; }
        public int EjercicioFiscal { get; set; }
        public string DescripcionPeriodo { get; set; } = string.Empty;
    }
    public class IniciarDeclaracionDataResult : BaseResult
    {
        public IniciarDeclaracionDtoResult Data { get; set; } = null!;
    }

    public class ResumenImpuestoDeclaracionViewModel
    {
        public decimal DerechoPatenteAnual { get; set; }
        public decimal ValoresBomberosPatente { get; set; }
        public decimal DescuentoAnticipoPagadoSri { get; set; }
        public decimal DescuentoPatenteTerceraEdad { get; set; }
        public decimal ReduccionDescensoUtilidad { get; set; }
        public decimal TotalPatentePagar { get; set; }
        public decimal MultaPatente { get; set; }

        public decimal ImpuestoActivos { get; set; }
        public decimal ValoresBomberos1_1000 { get; set; }
        public decimal DescuentoTerceraEdad15 { get; set; }
        public decimal Total15Pagar { get; set; }
        public decimal Multa15 { get; set; }

        public decimal TotalPagar { get; set; }
    }
}
