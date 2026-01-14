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
        public EndPointsConfig EndPointsConfig { get; set; } = null!;
        public ServerApisConfig ServerApisConfig { get; set; } = null!;
        public ConfiguracionesApp()
        {
            AppConfig = new AppConfig();
            EndPointsConfig = new EndPointsConfig();
            ServerApisConfig = new ServerApisConfig();
        }
    }
}

