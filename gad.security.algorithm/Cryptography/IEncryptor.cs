namespace gad.security.algorithm.Cryptography
{
    public interface IEncryptor : IEncryptorJsonSerializable
    {
        public byte[] Encrypt(byte[] data);
        public byte[] Encrypt(string data);
        public string EncryptEncoded(byte[] data);
        public string EncryptEncoded(string data);
        public byte[] Decrypt(byte[] data);
        public byte[] DecryptEncoded(string data);
    }
}
