using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.dataaccess;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/Consultas/")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly AaportalContext contexto;
        private readonly IConsultaServices services;

        public ConsultasController(AaportalContext contexto, IConsultaServices services)
        {
            this.contexto = contexto;
            this.services = services;
        }

        [HttpPost("ConsultaAnios")]
        public async Task<ActionResult<ConsultaAniosResponse>> ConsultaAnios([FromBody] ConsultaIdentificacionRequest parametros)
        {
            /* REQUEST SAMPLE
              "identificacion":"1091730940001"
             */
            ConsultaAniosResponse result = new ConsultaAniosResponse();
            try
            {
                return await services.ConsultaAnios(contexto, parametros);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpPost("ConsultaRazSocial")]
        public async Task<ActionResult<ConsultaRazSocialResponse>> ConsultaRazSocial([FromBody] ConsultaIdentificacionRequest parametros)
        {
            /* REQUEST SAMPLE
              "identificacion":"1091730940001"
             */
            ConsultaRazSocialResponse result = new ConsultaRazSocialResponse();
            try
            {
                return await services.ConsultaRazSocial(contexto, parametros);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpPost("ConsultaIngresosEgresos")]
        public async Task<ActionResult<ConsultaIngresosEgresosResponse>> ConsultaIngresosEgresos([FromBody] ConsultaIngresosEgresosRequest parametros)
        {
            /* REQUEST SAMPLE
              "identificacion":"1091730940001",
              "anio": 2024
             */
            ConsultaIngresosEgresosResponse result = new ConsultaIngresosEgresosResponse();
            try
            {
                return await services.ConsultaIngresosEgresos(contexto, parametros);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpGet("ConsultaCantones")]
        public async Task<ActionResult<CantonesResponse>> ConsultaCantones()
        {
            CantonesResponse result = new CantonesResponse();
            try
            {
                return await services.ConsultaCantones(contexto);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpGet("ConsultaTarifas")]
        public async Task<ActionResult<ListaTarifas>> ConsultaTarifas()
        {
            ListaTarifas result = new ListaTarifas();
            try
            {
                return await services.ConsultaTarifas(contexto);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpGet("ConsultaTasasAdministrativas")]
        public async Task<ActionResult<TasasAdministrativas>> ConsultaTasasAdministrativas()
        {
            TasasAdministrativas result = new TasasAdministrativas();
            try
            {
                return await services.ConsultaTasasAdministrativas(contexto);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpPost("ConsultaDeclaracion")]
        public async Task<ActionResult<DeclaracionResponse>> ConsultaDeclaracion([FromBody] ConsultaDeclaracionRequest parametos)
        {
            /* REQUEST SAMPLE
                "ruc": "1091730940001",
                "anioFiscal": 2024
             */
            DeclaracionResponse result = new DeclaracionResponse();
            try
            {
                return await services.ConsultaDeclaracion(contexto, parametos);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
    }
}
