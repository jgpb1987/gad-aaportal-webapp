namespace gad.aaportal.consumers.Js
{
    public interface ISessionStorageService
    {
        Task SetItemAsync(string key, string value);
        Task<string> GetItemAsync(string key);
        Task RemoveItemAsync(string key);
    }
}

