using gad.aaportal.commons.Base;
using gad.aaportal.commons.Dto.Seguridad;
using gad.aaportal.services.MessageException;
using gad.aaportal.services.Services.Interfaces;
using gad.security.algorithm.Cryptography;
using gad.security.algorithm.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Services.Implementation
{
    public class SecurityAlgorithmServices : ISecurityAlgorithmServices
    {
        private readonly ILogger<SecurityAlgorithmServices> logger;
        public SecurityAlgorithmServices(ILogger<SecurityAlgorithmServices> logger)
        {
            this.logger = logger;
        }
        public async Task<EncryptDecryptDataDtoResult> GetDecryptAes(EncryptDecryptDtoParam parametro)
        {
            EncryptDecryptDataDtoResult result = new();
            try
            {
                AesCbcEncryptor encryptorPkcs7PaddingBase64Encoder = new AesCbcEncryptor { KeyString = parametro.Key, Padding = AesCbcPadding.Pkcs7, Encoder = Base64Encoder.DefaultInstance };
                string decrypted = encryptorPkcs7PaddingBase64Encoder.DecryptEncoded(parametro.Data).ToStringUtf8();
                result.Data = new EncryptDecryptDtoResult() { EncryptDecrypt = decrypted };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
        public async Task<EncryptDecryptDataDtoResult> GetEncryptAes(EncryptDecryptDtoParam parametro)
        {
            EncryptDecryptDataDtoResult result = new();
            try
            {
                AesCbcEncryptor encryptorPkcs7PaddingBase64Encoder = new AesCbcEncryptor { KeyString = parametro.Key, Padding = AesCbcPadding.Pkcs7, Encoder = Base64Encoder.DefaultInstance };
                string encrypt = encryptorPkcs7PaddingBase64Encoder.EncryptEncoded(parametro.Data);
                result.Data = new EncryptDecryptDtoResult() { EncryptDecrypt = encrypt };

            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
        public async Task<EncryptDecryptDataDtoResult> GetEncryptRsa(EncryptDecryptDtoParam parametro)
        {
            EncryptDecryptDataDtoResult result = new();
            try
            {
                RsaPadding padding = RsaPadding.Pkcs1;
                IEncoder encoder = Base64Encoder.DefaultInstance;
                var secreto = RsaExtensions.EncryptEncodedRsa(parametro.Data, parametro.Key, encoder, padding);
                result.Data = new EncryptDecryptDtoResult() { EncryptDecrypt = secreto };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;

        }
        public async Task<EncryptDecryptDataDtoResult> GetDecryptRsa(EncryptDecryptDtoParam parametro)
        {
            EncryptDecryptDataDtoResult result = new();
            try
            {
                RsaPadding padding = RsaPadding.Pkcs1;
                IEncoder encoder = Base64Encoder.DefaultInstance;
                var secreto = RsaExtensions.DecryptEncodedRsa(parametro.Data, parametro.Key, encoder, padding).ToStringUtf8();
                result.Data = new EncryptDecryptDtoResult() { EncryptDecrypt = secreto };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
        public async Task<ComputeHashSha1DataDtoResult> GetGenerateComputeHashSha(ComputeHashSha1DtoParam parametro)
        {
            ComputeHashSha1DataDtoResult result = new();
            try
            {
                HashAlgorithm algorithm = HashAlgorithm.Sha1;
                var hash = HashExtensions.ComputeEncodedHash(parametro.Usuario + parametro.Password, HexEncoder.DefaultInstance, algorithm);
                result.Data = new ComputeHashSha1DtoResult() { Hash = hash };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
        public async Task<GenerarRsaDataDtoResult> GetGenerateRsa(GenerarRsaDtoParam parametro)
        {
            GenerarRsaDataDtoResult result = new();
            RsaKeyPair rsa;
            try
            {
                switch (parametro.RsaKeyPairEncoding)
                {
                    case "ber":
                        rsa = RsaExtensions.CreateRsaKeyPair(parametro.KeySize, RsaKeyPairEncoding.Ber);
                        result.Data = new GenerarRsaDtoResult() { KeySize = parametro.KeySize, RsaKeyPairEncoding = "Ber", PublicKey = rsa.PublicKey!, PrivateKey = rsa.PrivateKey! };
                        break;
                    case "pem":
                        rsa = RsaExtensions.CreateRsaKeyPair(parametro.KeySize, RsaKeyPairEncoding.Pem);
                        result.Data = new GenerarRsaDtoResult() { KeySize = parametro.KeySize, RsaKeyPairEncoding = "Pem", PublicKey = rsa.PublicKey!, PrivateKey = rsa.PrivateKey! };
                        break;
                    case "xml":
                        rsa = RsaExtensions.CreateRsaKeyPair(parametro.KeySize, RsaKeyPairEncoding.Xml);
                        result.Data = new GenerarRsaDtoResult() { KeySize = parametro.KeySize, RsaKeyPairEncoding = "Xml", PublicKey = rsa.PublicKey!, PrivateKey = rsa.PrivateKey! };
                        break;
                }
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
        public async Task<RandomDataDtoResult> GetRandomEncoder(RandomDtoParam parametro)
        {
            RandomDataDtoResult result = new();
            string random = string.Empty;
            try
            {
                switch (parametro.Encoder)
                {
                    case "hex":
                        HexEncoder encoderHex = new() { ToUpper = true };
                        random = encoderHex.Encode(RandomExtensions.NextBytes(parametro.Size));
                        break;
                    case "b32":
                        Base32Encoder encoderB32 = new Base32Encoder { RemovePadding = true, ToLower = false };
                        random = encoderB32.Encode(RandomExtensions.NextBytes(parametro.Size));
                        break;
                    case "b64":
                        Base64Encoder encoderB64 = Base64Encoder.DefaultInstance;
                        random = encoderB64.Encode(RandomExtensions.NextBytes(parametro.Size));
                        break;
                }
                result.Data = new() { Random = random, Encoder = parametro.Encoder };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }

        public async Task<SignatureHmacDataDtoResult> GetSignatureHmac(SignatureHmacDtoParam parametro)
        {
            SignatureHmacDataDtoResult result = new();
            try
            {
                IEncoder encoder = Base64Encoder.DefaultInstance;
                var firma = HashExtensions.ComputeEncodedHmac(parametro.JsonData, parametro.Secreto, encoder);
                result.Data = new SignatureHmacDtoResult() { Signature = firma };
            }
            catch (SystemExceptionCustomized sex)
            {
                logger.LogError(sex, sex.Description, sex.Code);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, nameof(CodeMessage.SERVER_ERROR));
                throw;
            }
            return result;
        }
    }
}
