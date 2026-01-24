using gad.security.algorithm.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.security.algorithm.Cryptography
{
    public interface IEncryptorJsonSerializable : IJsonSerializable
    {
        public static abstract IEncryptor Deserialize(string json);
    }
}
