using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Config
{
    public class AppConfig
    {
        public string Company { get; set; } = null!;
        public string CodeApp { get; set; } = null!;
        public int TimeToast { get; set; }
        public uint Size { get; set; }
        public uint SizeBytes { get; set; }
    }
}

