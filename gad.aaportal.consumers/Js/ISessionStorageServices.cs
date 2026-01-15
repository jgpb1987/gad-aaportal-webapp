using gad.aaportal.commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.consumers.Js
{
    public interface ISessionStorageServices
    {
        Task SetItemAsync(string key, string value);
        Task<string> GetItemAsync(string key);
        Task RemoveItemAsync(string key);
        Task<InfoBrowserUsuario> GetInfoDispositivoUsuario();
    }
}

