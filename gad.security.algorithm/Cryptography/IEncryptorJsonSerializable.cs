using gad.security.algorithm.Serialization;

namespace gad.security.algorithm.Cryptography
{
    public interface IEncryptorJsonSerializable : IJsonSerializable
    {
        public static abstract IEncryptor Deserialize(string json);
    }
}
