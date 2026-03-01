using gad.aaportal.commons.Dto.Seguridad;

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

