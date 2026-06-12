using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using Microsoft.AspNetCore.Http;
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
        public decimal Patrimonio { get; set; }
        public decimal DerechoPatenteAnual { get; set; }
        public decimal MultaPatente { get; set; }
        public decimal ValoresBomberosPatente { get; set; }
        public decimal DescuentoPatenteTerceraEdad { get; set; }
        public decimal TotalPatentePagar { get; set; }

        public decimal BaseImponible1_5_x_1000 { get; set; }
        public decimal ImpuestoActivos { get; set; }
        public decimal Multa15 { get; set; }
        public decimal DescuentoTerceraEdad15 { get; set; }
        public decimal Total15Pagar { get; set; }

        public decimal TotalPagar { get; set; }
    }
    public class RegistrarDeclaracionDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;
        public int Anio { get; set; }

        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorriente { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal PasivoContingente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal CostosGastos { get; set; }

        public decimal UnoCincoXMil { get; set; }
        public decimal Patente { get; set; }
        public decimal ValorBomberos { get; set; }

        public decimal MultaPatente { get; set; }
        public decimal MultaIat { get; set; }
        public decimal BaseImponiblePatente { get; set; }
        public decimal BaseImponibleIAT { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal PorcentajeDescuentoTerceraEdadPatente { get; set; }
        public decimal PorcentajeDescuentoTerceraEdadIAT { get; set; }
        public decimal PorcentajeCalculoIat { get; set; }
        public decimal ValorExoneradoPatente { get; set; }
        public decimal ValorExoneradoIAT { get; set; }
        public string ExedentePatente { get; set; } = string.Empty;
        public string ExedenteIAT { get; set; } = string.Empty;
        public decimal PorcentajeIngreso { get; set; }

        public decimal InteresPatente { get; set; }
        public decimal RecargoPatente { get; set; }
        public decimal CostasPatente { get; set; }
        public decimal TasaAdministrativaPatente { get; set; }

        public decimal InteresIat { get; set; }
        public decimal RecargoIat { get; set; }
        public decimal CostasIat { get; set; }
        public decimal TasaAdministrativaIat { get; set; }
    }

    public class RegistrarDeclaracionDtoResult
    {
        public long Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public int Anio { get; set; }
        public string CodigoUnicoPago { get; set; } = string.Empty;

        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorriente { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal PasivoContingente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal CostosGastos { get; set; }

        public decimal UnoCincoXMil { get; set; }
        public decimal Patente { get; set; }
        public decimal ValorBomberos { get; set; }
        public decimal MultaPatente { get; set; }
        public decimal MultaIat { get; set; }
        public decimal DescuentoTerceraEdadPatente { get; set; }
        public decimal DescuentoTerceraEdadIat { get; set; }

        public decimal InteresPatente { get; set; }
        public decimal RecargoPatente { get; set; }
        public decimal CostasPatente { get; set; }
        public decimal TasaAdministrativaPatente { get; set; }

        public decimal InteresIat { get; set; }
        public decimal RecargoIat { get; set; }
        public decimal CostasIat { get; set; }
        public decimal TasaAdministrativaIat { get; set; }
        public decimal TotalPagar => UnoCincoXMil + Patente + ValorBomberos + MultaPatente + MultaIat  + InteresPatente + RecargoPatente + CostasPatente + TasaAdministrativaPatente + InteresIat + RecargoIat + CostasIat + TasaAdministrativaIat - (DescuentoTerceraEdadPatente + DescuentoTerceraEdadIat);
    }

    public class RegistrarDeclaracionDataResult : BaseResult
    {
        public RegistrarDeclaracionDtoResult? Data { get; set; }
    }

    public class ConsultarDeclaracionContribuyenteDtoParam
    {
        public string Identificacion { get; set; } = string.Empty;
    }

    public class ConsultarDeclaracionContribuyenteDtoResult
    {
        public long Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public DateTime Fecha { get; set; }
        public int Anio { get; set; }
        public string CodigoUnicoPago { get; set; } = string.Empty;

        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorriente { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal PasivoContingente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal CostosGastos { get; set; }

        public decimal UnoCincoXMil { get; set; }
        public decimal Patente { get; set; }
        public decimal ValorBomberos { get; set; }
        public decimal MultaPatente { get; set; }
        public decimal MultaIat { get; set; }
        public decimal DescuentoTerceraEdadPatente { get; set; }
        public decimal DescuentoTerceraEdadIat { get; set; }

        public decimal InteresPatente { get; set; }
        public decimal RecargoPatente { get; set; }
        public decimal CostasPatente { get; set; }
        public decimal TasaAdministrativaPatente { get; set; }

        public decimal InteresIat { get; set; }
        public decimal RecargoIat { get; set; }
        public decimal CostasIat { get; set; }
        public decimal TasaAdministrativaIat { get; set; }
        public decimal TotalPagar => UnoCincoXMil + Patente + ValorBomberos + MultaPatente + MultaIat + InteresPatente + RecargoPatente + CostasPatente + TasaAdministrativaPatente + InteresIat + RecargoIat + CostasIat + TasaAdministrativaIat - (DescuentoTerceraEdadPatente + DescuentoTerceraEdadIat);

        public bool Estado { get; set; }
    }

    public class ConsultarDeclaracionContribuyenteListResult
    {
        public List<ConsultarDeclaracionContribuyenteDtoResult> Declaraciones { get; set; } = new();
    }

    public class ConsultarDeclaracionContribuyenteDataResult : BaseResult
    {
        public ConsultarDeclaracionContribuyenteListResult? Data { get; set; }
    }

    public class DeclaracionArchivoDtoResult
    {
        public long Id { get; set; }
        public long IdContribuyenteDeclaracion { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreArchivo { get; set; } = string.Empty;
        public string ExtensionArchivo { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }
    public class ConsultarDeclaracionArchivoDtoParam
    {
        public long IdContribuyenteDeclaracion { get; set; }
    }
    public class ConsultarDeclaracionArchivoListResult
    {
        public List<DeclaracionArchivoDtoResult> Archivos { get; set; } = new();
    }
    public class ConsultarDeclaracionArchivoDataResult : BaseResult
    {
        public ConsultarDeclaracionArchivoListResult? Data { get; set; }
    }
    public class SubirDeclaracionArchivoDtoResult : BaseResult
    {
        public DeclaracionArchivoDtoResult? Data { get; set; }
    }
    public class DescargarDeclaracionArchivoDtoResult
    {
        public long Id { get; set; }
        public string NombreArchivo { get; set; } = string.Empty;
        public string ExtensionArchivo { get; set; } = string.Empty;
        public string UbicacionArchivo { get; set; } = string.Empty;
    }
    public class SubirDeclaracionArchivoDtoParam
    {
        public long IdContribuyenteDeclaracion { get; set; }

        public IFormFile Archivo { get; set; } = default!;
    }
}
