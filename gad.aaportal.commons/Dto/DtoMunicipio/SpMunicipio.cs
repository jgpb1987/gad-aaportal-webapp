using gad.aaportal.commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.commons.Dto.DtoMunicipio
{
    public class CalcularImpuestoPatenteDtoParam
    {
        public decimal BaseImponible { get; set; }
    }
    public class CalcularImpuestoPatenteDtoDataResult
    {
        public decimal ValorImpuesto { get; set; }
    }

    public class CalcularImpuestoPatenteDtoResult : BaseResult
    {
        public CalcularImpuestoPatenteDtoDataResult Data { get; set; } = new();
    }

    public class CalcularImpuestoIatDtoParam
    {
        public decimal BaseImponible { get; set; }
    }
    public class CalcularImpuestoIatDtoDataResult
    {
        public decimal ImpuestoIat { get; set; }
    }

    public class CalcularImpuestoIatDtoResult : BaseResult
    {
        public CalcularImpuestoIatDtoDataResult Data { get; set; } = new();
    }

    public class CalcularMultaDtoParam
    {
        public string Ruc { get; set; } = null!;
        public int AnioDeclaracion { get; set; }
        public decimal Valor { get; set; }
    }

    public class CalcularMultaDtoDataResult
    {
        public int Meses { get; set; }
        public decimal Multa { get; set; }
    }

    public class CalcularMultaDtoResult : BaseResult
    {
        public CalcularMultaDtoDataResult Data { get; set; } = new();
    }
    public class CalcularTerceraEdadDtoParam
    {
        public decimal BasePatrimonio { get; set; }
        public decimal Ingresos { get; set; }
        public string Ruc { get; set; } = null!;
        public int Anio { get; set; }
        public decimal ValorImpuesto { get; set; }
        public string TipoImpuesto { get; set; } = null!;
    }

    public class CalcularTerceraEdadDtoDataResult
    {
        public decimal PorcentajePatrimonio { get; set; }
        public decimal PorcentajeIngresos { get; set; }
        public decimal PorcentajeAplicar { get; set; }
        public decimal ValorDescuento { get; set; }
        public string ExedenteAplicado { get; set; } = string.Empty;
        public decimal PorcentajeTe { get; set; }
        public decimal Patrimonio { get; set; }
        public string TipoImpuesto { get; set; } = string.Empty;
        public decimal SalarioBasico { get; set; }
        public decimal Ingresos { get; set; }
        public string Msj { get; set; } = string.Empty;
    }

    public class CalcularTerceraEdadDtoResult : BaseResult
    {
        public CalcularTerceraEdadDtoDataResult Data { get; set; } = new();
    }
    public class InsertActividadAnualDtoParam
    {
        public string Ruc { get; set; } = null!;
        public double IngresoTotales { get; set; }
        public double TotalActivos { get; set; }
        public double TotalPasivos { get; set; }
        public double Patrimonio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int AnioPatente { get; set; }
        public double BaseImponiblePatente { get; set; }
        public double TarifaPatente { get; set; }
        public double MultaPatente { get; set; }
        public double PorcentajeDescuentoTercera { get; set; }
        public string UsuarioIngreso { get; set; } = null!;
        public double Utilidad { get; set; }
        public double ContingenciaPasivos { get; set; }
        public double BaseImponibleIat { get; set; }
        public double ImpuestoIat { get; set; }
        public double MultaIat { get; set; }
        public double PorcentajeCalculoIat { get; set; }
        public double PorcentajeTeiat { get; set; }
    }

    public class InsertActividadAnualDtoDataResult
    {
        public int IdActividadGenerada { get; set; }
    }

    public class InsertActividadAnualDtoResult : BaseResult
    {
        public InsertActividadAnualDtoDataResult Data { get; set; } = new();
    }
    public class InsertTerceraEdadDtoParam
    {
        public int AnioCalculo { get; set; }
        public double PorcentajePatrimonio { get; set; }
        public double PorcentajeIngreso { get; set; }
        public double PorcentajeAplicar { get; set; }
        public double ValorDescuento { get; set; }
        public string ExedenteAplicado { get; set; } = string.Empty;
        public double PorcentajeTE { get; set; }
        public double Patrimonio { get; set; }
        public string TipoImpuesto { get; set; } = null!;
        public double Ingresos { get; set; }
        public double BaseImponible { get; set; }
        public double ImpuestoGravado { get; set; }
        public string UsuarioIngreso { get; set; } = null!;
        public int IdCalculoImpuesto { get; set; }
    }

    public class InsertTerceraEdadDtoDataResult
    {
        public bool Insertado { get; set; }
    }

    public class InsertTerceraEdadDtoResult : BaseResult
    {
        public InsertTerceraEdadDtoDataResult Data { get; set; } = new();
    }
    public class InsertPagoPorTituloDtoParam
    {
        public string Ruc { get; set; } = null!;
        public string CodTituloDatos { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaVencInteres { get; set; }
        public string UserIngreso { get; set; } = null!;
        public double BaseImponible { get; set; }
        public double Valor { get; set; }
        public double Multa { get; set; }
        public int AnioDeclaracion { get; set; }
        public double ValorPagadoOtroCanton { get; set; }
    }

    public class InsertPagoPorTituloDtoDataResult
    {
        public int CodigoIngreso { get; set; }
    }

    public class InsertPagoPorTituloDtoResult : BaseResult
    {
        public InsertPagoPorTituloDtoDataResult Data { get; set; } = new();
    }
    public class ActualizarCodigoIngresoDtoParam
    {
        public int CodigoIngreso { get; set; }
        public int IdDeclaracionAnual { get; set; }
        public string CodTitulo { get; set; } = null!;
    }

    public class ActualizarCodigoIngresoDtoDataResult
    {
        public bool Actualizado { get; set; }
    }

    public class ActualizarCodigoIngresoDtoResult : BaseResult
    {
        public ActualizarCodigoIngresoDtoDataResult Data { get; set; } = new();
    }
    public class ConsultarValoresPagarDtoParam
    {
        public int CodigoIngreso { get; set; }
    }

    public class ConsultarValoresPagarDetalleDtoDataResult
    {
        public decimal Valor { get; set; }
        public string DescripcionDescripcion { get; set; } = string.Empty;
    }

    public class ConsultarValoresPagarResumenDtoDataResult
    {
        public decimal Total { get; set; }
        public decimal RecargoTit { get; set; }
        public decimal Interes { get; set; }
        public decimal Recargo { get; set; }
        public decimal Descuento { get; set; }
        public decimal CostaJ { get; set; }
    }

    public class ConsultarValoresPagarDtoDataResult
    {
        public List<ConsultarValoresPagarDetalleDtoDataResult> Detalles { get; set; } = new();
        public ConsultarValoresPagarResumenDtoDataResult Resumen { get; set; } = new();
    }

    public class ConsultarValoresPagarDtoResult : BaseResult
    {
        public ConsultarValoresPagarDtoDataResult Data { get; set; } = new();
    }

    public class ValidadorPermisosDtoParam
    {
        public string Ruc { get; set; } = null!;
    }

    public class ValidadorPermisosDtoDataResult
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }

    public class ValidadorPermisosDtoResult : BaseResult
    {
        public ValidadorPermisosDtoDataResult Data { get; set; } = new();
    }

    public class ConsultarValorBomberosDtoParam
    {
        public string Ruc { get; set; } = null!;
    }

    public class ConsultarValorBomberosDtoDataResult
    {
        public string Ruc { get; set; } = string.Empty;
        public double ValorBomberos { get; set; }
    }

    public class ConsultarValorBomberosDtoResult : BaseResult
    {
        public ConsultarValorBomberosDtoDataResult Data { get; set; } = new();
    }
    public class ConsultarRucExoneracionesDtoParam
    {
        public string Ruc { get; set; } = null!;
    }

    public class ConsultarRucExoneracionesDtoDataResult
    {
        public string ExoneracionPatente { get; set; } = string.Empty;
        public string ExoneracionIat { get; set; } = string.Empty;
    }

    public class ConsultarRucExoneracionesDtoResult : BaseResult
    {
        public ConsultarRucExoneracionesDtoDataResult Data { get; set; } = new();
    }
    public class InsertarTranferenciaIatDtoParam
    {
        public string Canton { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public string FormaPago { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public double Valor { get; set; }
        public string UsuarioIngreso { get; set; } = "PATWEB";
        public string Banco { get; set; } = null!;
    }

    public class InsertarTranferenciaIatDtoDataResult
    {
        public bool Insertado { get; set; }
    }

    public class InsertarTranferenciaIatDtoResult : BaseResult
    {
        public InsertarTranferenciaIatDtoDataResult Data { get; set; } = new();
    }
    public class ConsultarAnioAdeudaDtoParam
    {
        public string Ruc { get; set; } = null!;
    }

    public class ConsultaAnioVencimientoDtoParam
    {
        public string Ruc { get; set; }
        public int Anio { get; set; }
    }

    public class ConsultarAnioAdeudaDtoDataResult
    {
        public int Anio { get; set; }
    }

    public class ConsultarAnioAdeudaDtoResult : BaseResult
    {
        public ConsultarAnioAdeudaDtoDataResult Data { get; set; } = new();
    }

    public class FechaVencimientoDtoResul
    {
        public string Id { get; set; }
        public string Parametro { get; set; }
        public string Descripcion { get; set; }
    }

    public class AnioVencimientoDtoResult : BaseResult
    {
        public FechaVencimientoDtoResul Data { get; set; } = new();
    }
    public class ConsultaValorPDtoParam
    {
        public decimal ValorImpuesto { get; set; }
        public decimal ValorMulta { get; set; }
        public string TipoImpuesto { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public int AnioDeclaracion { get; set; }
    }

    public class ConsultaValorPDtoDataResult
    {
        public decimal Intereses { get; set; }
        public decimal Recargo { get; set; }
        public decimal CostaJ { get; set; }
        public decimal TasaAdministrativa { get; set; }
    }

    public class ConsultaValorPDtoResult : BaseResult
    {
        public ConsultaValorPDtoDataResult Data { get; set; } = new();
    }
}
