using gad.aaportal.commons.Dto.Externs;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Utilitarian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.consumers.Implementation
{
    public class ServicesExternsConsumers : IServicesExternsConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public ServicesExternsConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<List<InfoRucResult>> SearchInfoRucSri(string identificacion)
        {
            List<InfoRucResult> result = new();
            try
            {
                result = await _httpClient.GetSinBr<List<InfoRucResult>>(configuraciones.ServerApisConfig.ApiServer1 + configuraciones.UriExternosConfig.GetContribuyenteSRI + identificacion);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<List<InfoEstablecimientoResult>> SearchInfoEstablecimientoSri(string identificacion)
        {
            List<InfoEstablecimientoResult> result = new();
            try
            {
                result = await _httpClient.GetSinBr<List<InfoEstablecimientoResult>>(configuraciones.ServerApisConfig.ApiServer1 + configuraciones.UriExternosConfig.GetEstablecimientosSRI + identificacion);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
