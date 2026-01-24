using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.security.algorithm.Cryptography
{
    public enum RsaKeyEncoding
    {
        Unknown,
        BerPublic,
        BerPrivate,
        PemPublic,
        PemPrivate,
        XmlPublic,
        XmlPrivate
    }
}
