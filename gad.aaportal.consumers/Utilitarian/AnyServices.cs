using gad.aaportal.commons.Base;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace gad.aaportal.consumers.Utilitarian
{
    public static class AnyServices
    {
        public static async Task<TResult> Get<TResult>(this HttpClient httpClient, string method) where TResult : BaseResult
        {
            TResult result;
            try
            {
                //string varjson = JsonSerializerDeserializer.Serialize(param!);
                var response = await httpClient.GetAsync(method);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = await response.Content.ReadFromJsonAsync<TResult>();
                    result ??= (TResult)Activator.CreateInstance(typeof(TResult))!;
                }
                else
                {
                    result = null!;
                }
            }
            catch (Exception ex)
            {
                result = null!;
            }
            return result!;
        }
        public static async Task<TResult> Post<TParam, TResult>(this HttpClient httpClient, TParam param, string method) where TResult : BaseResult
        {
            TResult result;
            try
            {
                //string varjson = JsonSerializerDeserializer.Serialize(param!);
                var response = await httpClient.PostAsJsonAsync(method, param);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = await response.Content.ReadFromJsonAsync<TResult>();
                    result ??= (TResult)Activator.CreateInstance(typeof(TResult))!;
                }
                else
                {
                    result = null!;
                }
            }
            catch (Exception ex)
            {
                result = null!;
            }
            return result!;
        }
        public static async Task<TResult> Post<TParam, TResult>(this HttpClient httpClient, TParam param, string method, string header, string valueHeader)
         where TResult : BaseResult
        {
            TResult result;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

                content.Headers.Add(header, valueHeader);

                var response = await httpClient.PostAsync(method, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = await response.Content.ReadFromJsonAsync<TResult>();
                    result ??= (TResult)Activator.CreateInstance(typeof(TResult));
                }
                else
                {
                    result = null!;
                }
            }
            catch (Exception ex)
            {
                result = null!;
                Console.WriteLine("ERROR:" + ex.Message);
            }
            return result!;
        }

        public static async Task<TResult> Post<TParam, TResult>(this HttpClient httpClient, TParam param, string method, Dictionary<string, string> customHeaders)
    where TResult : BaseResult
        {
            TResult result;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

                foreach (var header in customHeaders)
                {
                    if (header.Key.Equals("Authorization"))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.Value);
                    }
                    else
                    {
                        content.Headers.Add(header.Key, header.Value);
                    }
                }

                var response = await httpClient.PostAsync(method, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TResult>(jsonResponse)!;
                }
                else
                {
                    result = null!;
                }
            }
            catch (Exception ex)
            {
                result = null!;
                Console.WriteLine("ERROR:" + ex.Message);
            }
            return result!;
        }
    }
}
