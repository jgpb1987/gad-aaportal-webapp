using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.dataaccess.Configuration;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController
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
    }
}
