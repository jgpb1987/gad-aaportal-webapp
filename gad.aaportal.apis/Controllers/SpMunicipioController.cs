using gad.aaportal.commons.Dto.DtoMunicipio;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/SpMunicipio/")]
    [ApiController]
    public class SpMunicipioController : ControllerBase
    {
        private readonly ISpMunicipioServices services;
        public SpMunicipioController(ISpMunicipioServices services)
        {
            this.services = services;
        }

        [HttpPost("calcularImpuestoPatente")]
        public async Task<ActionResult<CalcularImpuestoPatenteDtoResult>> CalcularImpuestoPatente([FromBody] CalcularImpuestoPatenteDtoParam parametro)
        {
            CalcularImpuestoPatenteDtoResult result = new();

            try
            {
                result = await services.CalcularImpuestoPatente(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("calcularImpuestoIat")]
        public async Task<ActionResult<CalcularImpuestoIatDtoResult>> CalcularImpuestoIat([FromBody] CalcularImpuestoIatDtoParam parametro)
        {
            CalcularImpuestoIatDtoResult result = new();

            try
            {
                result = await services.CalcularImpuestoIat(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("calcularMulta")]
        public async Task<ActionResult<CalcularMultaDtoResult>> CalcularMulta([FromBody] CalcularMultaDtoParam parametro)
        {
            CalcularMultaDtoResult result = new();

            try
            {
                result = await services.CalcularMulta(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("calcularTerceraEdad")]
        public async Task<ActionResult<CalcularTerceraEdadDtoResult>> CalcularTerceraEdad([FromBody] CalcularTerceraEdadDtoParam parametro)
        {
            CalcularTerceraEdadDtoResult result = new();

            try
            {
                result = await services.CalcularTerceraEdad(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("insertActividadAnual")]
        public async Task<ActionResult<InsertActividadAnualDtoResult>> InsertActividadAnual([FromBody] InsertActividadAnualDtoParam parametro)
        {
            InsertActividadAnualDtoResult result = new();

            try
            {
                result = await services.InsertActividadAnual(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("insertTerceraEdad")]
        public async Task<ActionResult<InsertTerceraEdadDtoResult>> InsertTerceraEdad([FromBody] InsertTerceraEdadDtoParam parametro)
        {
            InsertTerceraEdadDtoResult result = new();

            try
            {
                result = await services.InsertTerceraEdad(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("insertPagoPorTitulo")]
        public async Task<ActionResult<InsertPagoPorTituloDtoResult>> InsertPagoPorTitulo([FromBody] InsertPagoPorTituloDtoParam parametro)
        {
            InsertPagoPorTituloDtoResult result = new();

            try
            {
                result = await services.InsertPagoPorTitulo(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("actualizarCodigoIngreso")]
        public async Task<ActionResult<ActualizarCodigoIngresoDtoResult>> ActualizarCodigoIngreso([FromBody] ActualizarCodigoIngresoDtoParam parametro)
        {
            ActualizarCodigoIngresoDtoResult result = new();

            try
            {
                result = await services.ActualizarCodigoIngreso(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarValoresPagar")]
        public async Task<ActionResult<ConsultarValoresPagarDtoResult>> ConsultarValoresPagar([FromBody] ConsultarValoresPagarDtoParam parametro)
        {
            ConsultarValoresPagarDtoResult result = new();

            try
            {
                result = await services.ConsultarValoresPagar(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("validadorPermisos")]
        public async Task<ActionResult<ValidadorPermisosDtoResult>> ValidadorPermisos([FromBody] ValidadorPermisosDtoParam parametro)
        {
            ValidadorPermisosDtoResult result = new();

            try
            {
                //result.Data = new() {Estado=false, Mensaje="Existen restricciones municipio." };
                result = await services.ValidadorPermisos(parametro);
                
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarValorBomberos")]
        public async Task<ActionResult<ConsultarValorBomberosDtoResult>> ConsultarValorBomberos([FromBody] ConsultarValorBomberosDtoParam parametro)
        {
            ConsultarValorBomberosDtoResult result = new();

            try
            {
                //result.Data=new ConsultarValorBomberosDtoDataResult() { ValorBomberos=5052.89 };
                result = await services.ConsultarValorBomberos( parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarRucExoneraciones")]
        public async Task<ActionResult<ConsultarRucExoneracionesDtoResult>> ConsultarRucExoneraciones([FromBody] ConsultarRucExoneracionesDtoParam parametro)
        {
            ConsultarRucExoneracionesDtoResult result = new();

            try
            {
                result = await services.ConsultarRucExoneraciones(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("insertarTranferenciaIat")]
        public async Task<ActionResult<InsertarTranferenciaIatDtoResult>> InsertarTranferenciaIat([FromBody] InsertarTranferenciaIatDtoParam parametro)
        {
            InsertarTranferenciaIatDtoResult result = new();

            try
            {
                result = await services.InsertarTranferenciaIat(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarAnioAdeuda")]
        public async Task<ActionResult<ConsultarAnioAdeudaDtoResult>> ConsultarAnioAdeuda([FromBody] ConsultarAnioAdeudaDtoParam parametro)
        {
            ConsultarAnioAdeudaDtoResult result = new();

            try
            {
                result = await services.ConsultarAnioAdeuda(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }

        [HttpPost("consultarAnioVencimiento")]
        public async Task<ActionResult<AnioVencimientoDtoResult>> ConsultarFechaVencimiento([FromBody] ConsultaAnioVencimientoDtoParam parametro)
        {
            AnioVencimientoDtoResult result = new();

            try
            {
                result = await services.ConsultarFechaVencimiento(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultaValorP")]
        public async Task<ActionResult<ConsultaValorPDtoResult>> ConsultaValorP( [FromBody] ConsultaValorPDtoParam parametro)
        {
            ConsultaValorPDtoResult result = new();

            try
            {
                result = await services.ConsultaValorP(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarEstadoRuc")]
        public async Task<ActionResult<ConsultarEstadoRucDtoResult>> ConsultarEstadoRuc([FromBody] ConsultarEstadoRucDtoParam parametro)
        {
            ConsultarEstadoRucDtoResult result = new();

            try
            {
                result = await services.ConsultarEstadoRuc(parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpGet("consultarMensaje")]
        public async Task<ActionResult<ConsultarMensajeDtoResult>> ConsultarMensaje()
        {
            ConsultarMensajeDtoResult result = new();

            try
            {
                result = await services.ConsultarMensaje();
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
    }
}
