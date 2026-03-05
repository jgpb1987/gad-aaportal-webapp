using gad.aaportal.commons.Dto.Dinardap;
using gad.aaportal.dataaccess;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/Dinardap/")]
    [ApiController]
    public class DinardapController : ControllerBase
    {
        private readonly AaportalContext contexto;
        private readonly IDinardapService services;

        public DinardapController(AaportalContext contexto, IDinardapService services)
        {
            this.contexto = contexto;
            this.services = services;
        }

        [HttpPost("PaqueteIndividual")]
        public async Task<ConsumoDinardapResult> PaqueteIndividual([FromBody] PaqueteDinardapRequest request)
        {
            return await services.ConsultPackage(contexto, request);
        }
        [HttpPost("searchRucListPackage")]
        public async Task<ConsumoDinardapResult> SearchRucListPackage([FromBody] PaqueteDinardapListRequest request)
        {
            return await services.SearchRucListPackage(contexto, request);
        }
    }
}
