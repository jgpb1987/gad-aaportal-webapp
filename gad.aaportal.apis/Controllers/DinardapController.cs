using gad.aainteroperador.soap.Client;
using gad.aainteroperador.soap.Configuration;
using gad.aaportal.apis.Common;
using gad.aaportal.commons.Dto;
using gad.aaportal.dataaccess;
using gad.aaportal.services.Services.Interfaces;
using gad.interoperador;
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
      
        [HttpPost("ConsultaDinardap")]
        public async Task<ConsumoDinardapResult> ConsultaDinardap([FromBody] string identificacion)
        {
            ConsumoDinardapResult result = new();
            try
            {
                var options = new SoapClientOptions
                {
                    Endpoint = "http://127.0.0.1:8088/mockinteroperadorSoapBinding", //http
                    //Endpoint = "http://interoperabilidad.dinardap.gob.ec/interoperador-v2", //QA

                    Security = new SoapSecurityOptions
                    {
                        Type = SoapSecurityType.None
                        //Type = SoapSecurityType.Basic, //QA
                        //Username = "InAtRoGeMu", //QA
                        //Password = "NKG3jt5%zFWeWZ" //QA
                    }
                };

                var service = new InteroperadorSoapService(options);

                var parametros = new[]
                {
                    new parametro { nombre = "codigoPaquete", valor = "6281" },
                    new parametro { nombre = "identificacion", valor = identificacion },
                    new parametro { nombre = "fuenteDatos", valor = "T" }
                };

                var response = await service.ConsultarAsync(parametros);
                if(response.paquete.numeroPaquete == "6281")
                {
                    var Form101 = Utilitarios.MapearAForm101Lista(response);
                    result.SaveForm101 = await services.SaveForm101(contexto, Form101);
                }
                

                parametros = new[]
                {
                    new parametro { nombre = "codigoPaquete", valor = "6282" },
                    new parametro { nombre = "identificacion", valor = identificacion },
                    new parametro { nombre = "fuenteDatos", valor = "T" }
                };
                response = await service.ConsultarAsync(parametros);
                if (response.paquete.numeroPaquete == "6282")
                {
                    var Form102 = Utilitarios.MapearAForm102Lista(response);
                    result.SaveForm102 = await services.SaveForm102(contexto, Form102);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
