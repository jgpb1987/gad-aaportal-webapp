using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Config
{
    public class SesionStorageConfig
    {
        public string DataApp { get; set; } = null!;
        public string PublicKey { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
        public string PublicKeyServer { get; set; } = null!;
        public string Expiration { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string SessionKey { get; set; } = null!;
        public string RandomKey { get; set; } = null!;
    }
}

