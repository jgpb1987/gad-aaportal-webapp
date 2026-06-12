using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.DtoPortal.Declaracion;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly AaportalContext contexto;
        private readonly IContribuyenteServices services;
        public ContribuyenteController(AaportalContext contexto, IContribuyenteServices services)
        {
            this.contexto = contexto;
            this.services = services;
        }

        [HttpPost("resumenContribuyente")]
        public async Task<ActionResult<ContribuyenteResumenDataDtoResult>> GetResumenContribuyente([FromBody] ContribuyenteResumenDtoParam parametro)
        {
            ContribuyenteResumenDataDtoResult result = new();
            try
            {
                result = await services.ResumenContribuyente(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpPost("consultarDatosContribuyente")]
        public async Task<ActionResult<ConsultarDatosContribuyenteDataResult>> ConsultarDatosContribuyente([FromBody] ConsultarDatosContribuyenteDtoParam parametro)
        {
            ConsultarDatosContribuyenteDataResult result = new();

            try
            {
                result = await services.ConsultarDatosContribuyente(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }

        [HttpPost("actualizarDatosContribuyente")]
        public async Task<ActionResult<ActualizarDatosContribuyenteDataResult>> ActualizarDatosContribuyente([FromBody] ActualizarDatosContribuyenteDtoParam parametro)
        {
            ActualizarDatosContribuyenteDataResult result = new();

            try
            {
                result = await services.ActualizarDatosContribuyente(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }

        [HttpPost("consultarTiposMedioContacto")]
        public async Task<ActionResult<TipoMedioContactoDataResult>> ConsultarTiposMedioContacto()
        {
            TipoMedioContactoDataResult result = new();
            try
            {
                result = await services.ConsultarTiposMedioContacto(contexto);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }
        [HttpPost("consultarPeriodosDeclaracion")]
        public async Task<ActionResult<PeriodoDeclaracionDataResult>> ConsultarPeriodosDeclaracion([FromBody] ContribuyenteDtoParam parametro)
        {
            PeriodoDeclaracionDataResult result = new();

            try
            {
                result = await services.ConsultarPeriodosDeclaracion(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }

        [HttpPost("consultarPeriodosDeclaracionMunicipio")]
        public async Task<ActionResult<PeriodoDeclaracionDataResult>> ConsultarPeriodosDeclaracionMunicipio([FromBody] ContribuyenteDtoParam parametro)
        {
            PeriodoDeclaracionDataResult result = new();

            try
            {
                result = await services.ConsultarPeriodosDeclaracionMunicipio(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }

        [HttpPost("iniciarDeclaracion")]
        public async Task<ActionResult<IniciarDeclaracionDataResult>> IniciarDeclaracion(
            [FromBody] IniciarDeclaracionDtoParam parametro)
        {
            IniciarDeclaracionDataResult result = new();

            try
            {
                result = await services.IniciarDeclaracion(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }
        [HttpPost]
        [Route("registrarDeclaracion")]
        public async Task<ActionResult<RegistrarDeclaracionDataResult>> RegistrarDeclaracion([FromBody] RegistrarDeclaracionDtoParam parametro)
        {
            RegistrarDeclaracionDataResult result = new();
            try
            {
                result = await services.RegistrarDeclaracion(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("ConsultarDeclaracionesContribuyente")]
        public async Task<ActionResult<ConsultarDeclaracionContribuyenteDataResult>> ConsultarDeclaracionesContribuyente([FromBody] ConsultarDeclaracionContribuyenteDtoParam parametro)
        {
            var result = await services.ConsultarDeclaracionesContribuyente(contexto, parametro);
            return Ok(result);
        }
        [HttpPost("subirArchivoDeclaracion")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10_000_000)]
        public async Task<ActionResult<SubirDeclaracionArchivoDtoResult>> SubirArchivoDeclaracion(
            [FromForm] SubirDeclaracionArchivoDtoParam parametro)
        {
            SubirDeclaracionArchivoDtoResult result = new();

            try
            {
                result = await services.SubirArchivoDeclaracion(contexto,
                    parametro.IdContribuyenteDeclaracion,
                    parametro.Archivo);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpPost("consultarArchivosDeclaracion")]
        public async Task<ActionResult<ConsultarDeclaracionArchivoDataResult>> ConsultarArchivosDeclaracion([FromBody] ConsultarDeclaracionArchivoDtoParam parametro)
        {
            ConsultarDeclaracionArchivoDataResult result = new();

            try
            {
                result = await services.ConsultarArchivosDeclaracion(contexto,parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }

            return result;
        }
        [HttpGet("descargarArchivoDeclaracion/{idArchivo:long}")]
        public async Task<IActionResult> DescargarArchivoDeclaracion(long idArchivo)
        {
            try
            {
                var archivo = await services.ObtenerArchivoDeclaracion(contexto, idArchivo);

                if (archivo is null ||
                    string.IsNullOrWhiteSpace(archivo.UbicacionArchivo) ||
                    !System.IO.File.Exists(archivo.UbicacionArchivo))
                {
                    return NotFound("No se encontró el archivo solicitado.");
                }

                var bytes = await System.IO.File.ReadAllBytesAsync(archivo.UbicacionArchivo);

                var contentType = archivo.ExtensionArchivo.ToLowerInvariant() switch
                {
                    ".pdf" => "application/pdf",
                    ".doc" => "application/msword",
                    ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ".xls" => "application/vnd.ms-excel",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => "application/octet-stream"
                };

                return File(bytes, contentType, archivo.NombreArchivo);
            }
            catch
            {
                return StatusCode(500, "No fue posible descargar el archivo.");
            }
        }
    }
}
