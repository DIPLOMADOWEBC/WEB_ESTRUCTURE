using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Base
{
    public class SunatClient : ISunatClient
    {
        private readonly HttpClient _httpClient;
        public SunatClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApiRuc"]) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<HttpResponseMessage> PostAsJsonAsync(string endpoint, object data, string args = null)
        {
            var response = await _httpClient.PostAsJsonAsync($"{endpoint}", data);
            return response;
        }

        public Task<HttpResponseMessage> PutAsJsonAsync(string endpoint, object data, string args = null)
        {
            throw new NotImplementedException();
        }
    }
}
