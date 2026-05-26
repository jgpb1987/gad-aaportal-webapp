using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Declaracion;
using gad.aaportal.commons.Dto.Seguridad;
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
    public class ContribuyenteConsumers : IContribuyenteConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public ContribuyenteConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<ContribuyenteResumenDataDtoResult> ResumenContribuyente(ContribuyenteResumenDtoParam parametro)
        {
            ContribuyenteResumenDataDtoResult result = new();
            try
            {
                result = await _httpClient.Post<ContribuyenteResumenDtoParam, ContribuyenteResumenDataDtoResult>(parametro, configuraciones.EndPointsConfig.GetResumenContribuyente);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
