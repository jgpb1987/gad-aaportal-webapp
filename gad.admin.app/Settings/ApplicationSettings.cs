using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.admin.app.Settings
{
    public class ApplicationSettings
    {
        public string ApiServer { get; set; } = string.Empty;
        public string EndPointPaqueteIndividuatl { get; set; } = string.Empty;
        public string UsuarioProceso { get; set; } = null!;
    }
}
