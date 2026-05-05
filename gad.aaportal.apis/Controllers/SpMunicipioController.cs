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
        private readonly BddGmaaContext contexto;
        private readonly ISpMunicipioServices services;
        public SpMunicipioController(BddGmaaContext contexto, ISpMunicipioServices services)
        {
            this.contexto = contexto;
            this.services = services;
        }

        [HttpPost("calcularImpuestoPatente")]
        public async Task<ActionResult<CalcularImpuestoPatenteDtoResult>> CalcularImpuestoPatente([FromBody] CalcularImpuestoPatenteDtoParam parametro)
        {
            CalcularImpuestoPatenteDtoResult result = new();

            try
            {
                result = await services.CalcularImpuestoPatente(contexto, parametro);
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
                result = await services.CalcularImpuestoIat(contexto, parametro);
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
                result = await services.CalcularMulta(contexto, parametro);
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
                result = await services.CalcularTerceraEdad(contexto, parametro);
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
                result = await services.InsertActividadAnual(contexto, parametro);
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
                result = await services.InsertTerceraEdad(contexto, parametro);
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
                result = await services.InsertPagoPorTitulo(contexto, parametro);
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
                result = await services.ActualizarCodigoIngreso(contexto, parametro);
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
                result = await services.ConsultarValoresPagar(contexto, parametro);
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
                result = await services.ValidadorPermisos(contexto, parametro);
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
                result = await services.ConsultarValorBomberos(contexto, parametro);
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
                result = await services.ConsultarRucExoneraciones(contexto, parametro);
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
                result = await services.InsertarTranferenciaIat(contexto, parametro);
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
                result = await services.ConsultarAnioAdeuda(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
    }
}
