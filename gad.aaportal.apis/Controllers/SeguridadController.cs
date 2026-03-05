using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.dataaccess;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/Seguridad/")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly AaportalContext contexto;
        private readonly ISeguridadServices services;
        public SeguridadController(AaportalContext contexto, ISeguridadServices services)
        {
            this.contexto = contexto;
            this.services = services;
        }
        [HttpGet("helloworld")]
        public async Task<ActionResult<string>> GetHelloWorld()
        {
            return await services.HelloWorld();
        }
        [HttpGet("publicKey")]
        public async Task<ActionResult<RsaDtoResult>> GetPublicKey()
        {
            RsaDtoResult result = new();
            try
            {
                result = await services.GetRsaPublicKey(contexto);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDtoResult>> GetLogin([FromBody] UsuarioDtoParam parametro)
        {
            UsuarioDtoResult result = new();
            try
            {
                result = await services.Login(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
        [HttpPost("userRegistration")]
        public async Task<ActionResult<BaseResult>> GetUserRegistration([FromBody] UserRegistrationDtoParam parametro)
        {
            BaseResult result = new();
            try
            {
                result = await services.GetUserRegistration(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
        [HttpPost("forgotPassword")]
        public async Task<ActionResult<BaseResult>> GetForgotPassword([FromBody] ForgotPasswordDtoParam parametro)
        {
            BaseResult result = new();
            try
            {
                result = await services.GetForgotPassword(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
    }
}

