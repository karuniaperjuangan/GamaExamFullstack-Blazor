using System;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace GamaExamFullstack.Data
{
    public class CustomHttpClient : HttpClient
    {
        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
                using var httpContent = await httpClient.GetAsync(requestUri);
                string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
                T obj = JsonConvert.DeserializeObject<T>(jsonContent);
                return obj; 

        }
        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);
            return response;
        }
        public async Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T content)
        {
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(requestUri, stringContent);
            return response;
        }

        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5001")
        };

        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    }

}
