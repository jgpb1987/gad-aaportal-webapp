using gad.aaportal.commons.Base;

namespace gad.aaportal.commons.Dto.Seguridad
{
    public class GenerarRsaDtoParam
    {
        public uint KeySize { get; set; }
        public string RsaKeyPairEncoding { get; set; } = null!;
    }
    public class GenerarRsaDtoResult
    {
        public string PublicKey { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
        public uint KeySize { get; set; }
        public string RsaKeyPairEncoding { get; set; } = null!;
    }
    public class GenerarRsaDataDtoResult : BaseResult
    {
        public GenerarRsaDtoResult Data { get; set; } = null;
    }

    public class ComputeHashSha1DtoParam
    {
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class ComputeHashSha1DtoResult
    {
        public string Hash { get; set; } = null!;
    }
    public class ComputeHashSha1DataDtoResult : BaseResult
    {
        public ComputeHashSha1DtoResult Data { get; set; } = null!;
    }

    public class EncryptDecryptDtoParam
    {
        public string Key { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
    public class EncryptDecryptDtoResult
    {
        public string EncryptDecrypt { get; set; } = null!;
    }
    public class EncryptDecryptDataDtoResult : BaseResult
    {
        public EncryptDecryptDtoResult Data { get; set; } = null!;
    }
    public class RandomDtoParam
    {
        public string Encoder { get; set; } = null!;
        public uint Size { get; set; }

    }
    public class RandomDtoResult
    {
        public string Random { get; set; } = null!;
        public string Encoder { get; set; } = null!;
    }
    public class RandomDataDtoResult : BaseResult
    {
        public RandomDtoResult Data { get; set; } = null!;
    }
    public class SignatureHmacDtoParam
    {
        public string Secreto { get; set; } = null!;
        public string JsonData { get; set; } = null!;
    }
    public class SignatureHmacDtoResult
    {
        public string Signature { get; set; } = null!;
    }
    public class SignatureHmacDataDtoResult : BaseResult
    {
        public SignatureHmacDtoResult Data { get; set; } = null!;
    }
}
