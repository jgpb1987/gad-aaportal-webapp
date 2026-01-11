using gad.aaportal.commons.Dto;
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
    }
}

