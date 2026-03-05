using gad.security.algorithm.Serialization;

namespace gad.security.algorithm.Cryptography
{
    public interface IEncoderJsonSerializable : IJsonSerializable
    {
        public static abstract IEncoder Deserialize(string json);
    }
}
