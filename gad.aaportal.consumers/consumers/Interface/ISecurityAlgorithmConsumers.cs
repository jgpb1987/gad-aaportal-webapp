using Microsoft.JSInterop;

namespace gad.aaportal.consumers.Consumers.Interface
{
    public interface ISecurityAlgorithmConsumers
    {
        public Task<string> EncryptRsa(IJSRuntime js, string data, string publicKey);
    }
}
