using gad.aaportal.consumers.Config;
using gad.aaportal.consumers.Consumers.Interface;
using gad.security.algorithm.Cryptography;
using gad.security.algorithm.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Consumers.Implementation
{
    public class SecurityAlgorithmConsumers : ISecurityAlgorithmConsumers
    {
        private ConfiguracionesApp configuraciones { get; set; }
        public SecurityAlgorithmConsumers(ConfiguracionesApp configuraciones)
        {
            this.configuraciones = configuraciones;
        }
        public async Task<string> EncryptRsa(IJSRuntime js, string data, string publicKey)
        {
            string result;
            try
            {
                IEncoder encoder = Base64Encoder.DefaultInstance;
                RsaPadding padding = RsaPadding.Pkcs1;
                var texto_encryptado = await js.EncryptEncodedRsaAsync(data, publicKey, Base64Encoder.DefaultInstance, padding);
                result = texto_encryptado;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
