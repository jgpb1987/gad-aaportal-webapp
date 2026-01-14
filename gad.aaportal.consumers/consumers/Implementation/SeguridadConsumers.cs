using gad.aaportal.commons.Dto;
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
    public class SeguridadConsumers : ISeguridadConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public SeguridadConsumers(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<RsaDtoResult> GetPublicKey()
        {
            RsaDtoResult result = new();
            try
            {
                result = await _httpClient.Get<RsaDtoResult>(configuraciones.EndPointsConfig.GetPublicKey);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public Task<UsuarioDtoResult> Login(UsuarioDtoParam parametro)
        {
            throw new NotImplementedException();
        }
    }
}
