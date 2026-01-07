using gad.aaportal.consumers.Js;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.webapp.Js
{
    public class WebSessionStorageService : ISessionStorageService
    {
        private readonly IJSRuntime _jsRuntime;
        public WebSessionStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SaveLocalStorage(string llave, string content)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", llave, content);
        }
        public async Task<string> ObtainLocalStorage(string llave)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", llave);
        }
        public async Task RemoveLocalStorage(string llave)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", llave);
        }
        public async Task SaveSesionStorage(string llave, string content)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", llave, content);
        }
        public async Task<string> ObtainSesionStorage(string llave)
        {
           return await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", llave);
        }
        public async Task RemoveSesionStorage(string llave)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", llave);
        }

        public async Task SetItemAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", key, value);
        }

        public async Task<string> GetItemAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);
        }
    }
}

