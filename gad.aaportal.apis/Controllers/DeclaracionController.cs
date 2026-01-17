using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gad.aaportal.apis.Controllers
{
    [Route("api/Declaracion/")]
    [ApiController]
    public class DeclaracionController : ControllerBase
    {
        private readonly AaportalContext contexto;
        private readonly IDeclaracionServices services;

        public DeclaracionController(AaportalContext contexto, IDeclaracionServices services)
        {
            this.contexto = contexto;
            this.services = services;
        }

        [HttpPost("DeclaracionPJ")]
        public async Task<ActionResult<SaveDeclaracionPJResult>> GrabarDeclaracionPJ([FromBody] DeclaracionRequest parametros)
        {
            /* REQUEST SAMPLE
            "declaracion": {
                "ruc": "1091730940001",
                "anioFiscal": 2024,
                "totalActivoCorriente470": 16603.36,
                "totActivoNoCorriente1077": 52912.58,
                "totPasivosCorrientes1340": 4140.06,
                "totalPasivosLargoPlazo1590": 0,
                "totalPasivosContingente": 0,
                "valorUnoPuntoCinco": 0,
                "totalIngresos1930": 128590.68,
                "totasCostosGastos3380": 126090.94,
                "utilidadEjercicio3420": 2499.74,
                "valorunopormil": 98.07
            },
            "cantones": [
            {
                "id": 116,
                "provincia": "string",
                "nombreCanton": "string",
                "seleccionado": true,
                "porcentaje": 50,
                "pagoAA": true
            },
            {
                "id": 115,
                "provincia": "string",
                "nombreCanton": "string",
                "seleccionado": true,
                "porcentaje": 50,
                "pagoAA": false
            }
            ]
             */
            SaveDeclaracionPJResult result = new SaveDeclaracionPJResult();
            try
            {
                return await services.GrabarDeclaracionPJ(contexto, parametros);
            }
            catch (Exception ex)
            {
                result.Message = SystemExceptionCustomized.GetError(ex);
            }
            return result;
        }
    }
}
