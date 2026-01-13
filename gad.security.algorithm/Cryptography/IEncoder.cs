using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.security.algorithm.Cryptography
{
    public interface IEncoder : IEncoderJsonSerializable
    {
        public string Encode(byte[] data);
        public string Encode(string data);
        public byte[] Decode(string data);
    }
}
