using gad.aainteroperador.soap.Configuration;
using gad.interoperador;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace gad.aainteroperador.soap.Client
{
    public class InteroperadorSoapService
    {
        private readonly interoperadorClient _client;

        public InteroperadorSoapService(SoapClientOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.Endpoint))
                throw new ArgumentException("Endpoint SOAP no configurado");

            var binding = CreateBinding(options.Security);
            //var binding = CreateBindingHttps(options.Security); //https
            var endpoint = new EndpointAddress(options.Endpoint);

            _client = new interoperadorClient(binding, endpoint);

            if (options.Security != null)
            {
                ApplySecurity(options.Security);
            }
        }

        private static Binding CreateBinding(SoapSecurityOptions? security)
        {
            var binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                AllowCookies = true
            };

            if (security == null || security.Type == SoapSecurityType.None)
            {
                binding.Security.Mode = BasicHttpSecurityMode.None;
            }
            else if (security.Type == SoapSecurityType.Basic)
            {
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            }

            return binding;
        }

        private static Binding CreateBindingHttps(SoapSecurityOptions? security)
        {
            var binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                AllowCookies = true
            };

            if (security == null || security.Type == SoapSecurityType.None)
            {
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
            }
            else if (security.Type == SoapSecurityType.Basic)
            {
                binding.Security.Mode = BasicHttpSecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            }

            return binding;
        }


        private void ApplySecurity(SoapSecurityOptions security)
        {
            if (security.Type == SoapSecurityType.Basic)
            {
                _client.ClientCredentials.UserName.UserName = security.Username;
                _client.ClientCredentials.UserName.Password = security.Password;
            }
        }

        public Task<consultarResponse> ConsultarAsync(parametro[] parametros)
        {
            return _client.consultarAsync(parametros);
        }
    }
}
