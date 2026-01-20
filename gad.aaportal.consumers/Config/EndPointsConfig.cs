using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Config
{
    public class EndPointsConfig
    {
        public string GetPublicKey { get; set; } = null!;
        public string GetLogin { get; set; } = null!;
        public string GetUserRegistration { get; set; } = null!;
    }
}

