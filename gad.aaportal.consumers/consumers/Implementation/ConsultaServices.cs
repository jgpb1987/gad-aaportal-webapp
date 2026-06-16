using gad.aaportal.commons.Dto.Aplicacion;
using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.consumers.Interface;
using gad.aaportal.consumers.Utilitarian;

namespace gad.aaportal.consumers.consumers.Implementation
{
    public class ConsultaServices : IConsultaServices
    {
        private ConfiguracionesApp configuraciones { get; set; }
        private readonly HttpClient _httpClient;
        public ConsultaServices(HttpClient httpClient, ConfiguracionesApp configuraciones)
        {
            _httpClient = httpClient;
            this.configuraciones = configuraciones;
        }
        public async Task<CantonesResponse> ConsultaCantones()
        {
            CantonesResponse result = new();
            try
            {
                result = await _httpClient.GetSinBr<CantonesResponse>(configuraciones.ServerApisConfig.ApiServer1 + configuraciones.EndPointsConfig.ConsultarCantones);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
