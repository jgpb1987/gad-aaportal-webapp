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
    }
}
