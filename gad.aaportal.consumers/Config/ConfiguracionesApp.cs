using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Config
{
    public class ConfiguracionesApp
    {
        public AppConfig AppConfig { get; set; } = null!;
        public SesionStorageConfig SesionStorageConfig { get; set; } = null!;
        public EndPointsConfig EndPointsConfig { get; set; } = null!;
    }
}

