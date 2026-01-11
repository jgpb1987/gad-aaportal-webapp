using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.services.MessageException;
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

        [HttpPost("SaveForm101")]
        public async Task<ActionResult<Form101SaveDtoResult>> PostSaveForm101([FromBody] Form101DtoRequest parametro)
        {
            /* REQUEST SAMPLE
              "anioFiscal": 2013,
              "numeroIdentificacion": "1091730940001",
              "razonSocial": "AUDIT &amp; PLANNING S.A. CONSULTORES AUDITORES",
              "perdidaEjercicio3430": 8578.59000000000015,
              "totActivoNoCorriente1077": 45167.5199999999968,
              "totPasivosCorrientes1340": 44202.4400000000023,
              "totalActivo1080": 76764.4400000000023,
              "totalActivoCorriente470": 31596.9199999999983,
              "totalIngresos1930": 99771.0500000000029,
              "totalPasivos1620": 45190.4400000000023,
              "totalPatrimonioNeto1780": 31574,
              "totasCostosGastos3380": 108349.639999999999,
              "utilidadEjercicio3420": 0,
              "totalPasivosLargoPlazo1590": 988,
              "proNoctePasCtgComNeg1577": 0
             */
            Form101SaveDtoResult result = new Form101SaveDtoResult();
            try
            {
                return await services.SaveDinardapResult(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }

        [HttpPost("UpdateForm101")]
        public async Task<ActionResult<Form101SaveDtoResult>> PostUpdateForm101([FromBody] Form101DtoRequest parametro)
        {
            /* REQUEST SAMPLE
              "anioFiscal": 2013,
              "numeroIdentificacion": "1091730940001",
              "razonSocial": "AUDIT &amp; PLANNING S.A. CONSULTORES AUDITORES",
              "perdidaEjercicio3430": 8578.59000000000015,
              "totActivoNoCorriente1077": 45167.5199999999968,
              "totPasivosCorrientes1340": 44202.4400000000023,
              "totalActivo1080": 76764.4400000000023,
              "totalActivoCorriente470": 31596.9199999999983,
              "totalIngresos1930": 99771.0500000000029,
              "totalPasivos1620": 45190.4400000000023,
              "totalPatrimonioNeto1780": 31574,
              "totasCostosGastos3380": 108349.639999999999,
              "utilidadEjercicio3420": 0,
              "totalPasivosLargoPlazo1590": 988,
              "proNoctePasCtgComNeg1577": 0
             */
            Form101SaveDtoResult result = new Form101SaveDtoResult();
            try
            {
                return await services.UpdateDinardapResult(contexto, parametro);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
    }
}
