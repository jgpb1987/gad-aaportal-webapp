using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Consumers.Interface
{
    public interface ISecurityAlgorithmConsumers
    {
        public Task<string> EncryptRsa(IJSRuntime js, string data, string publicKey);
    }
}
