using gad.aaportal.commons.Dto.Seguridad;

namespace gad.aaportal.services.Services.Interfaces
{
    public interface ISecurityAlgorithmServices
    {
        public Task<GenerarRsaDataDtoResult> GetGenerateRsa(GenerarRsaDtoParam parametro);
        public Task<ComputeHashSha1DataDtoResult> GetGenerateComputeHashSha(ComputeHashSha1DtoParam parametro);
        public Task<EncryptDecryptDataDtoResult> GetEncryptAes(EncryptDecryptDtoParam parametro);
        public Task<EncryptDecryptDataDtoResult> GetDecryptAes(EncryptDecryptDtoParam parametro);
        public Task<RandomDataDtoResult> GetRandomEncoder(RandomDtoParam parametro);
        public Task<EncryptDecryptDataDtoResult> GetEncryptRsa(EncryptDecryptDtoParam parametro);
        public Task<EncryptDecryptDataDtoResult> GetDecryptRsa(EncryptDecryptDtoParam parametro);
        public Task<SignatureHmacDataDtoResult> GetSignatureHmac(SignatureHmacDtoParam parametro);
    }
}
