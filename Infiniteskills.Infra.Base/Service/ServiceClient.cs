﻿using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Base
{
    public class ServiceClient : IServiceClient
    {
        private readonly HttpClient _httpClient;
        public ServiceClient()
        {
            _httpClient = new HttpClient{BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApiRest"]) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> GetAsync<T>(string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task PostAsync(string endpoint, object data, string args = null)
        {
            var payload = GetPayload(data);
            await _httpClient.PostAsync($"{endpoint}?{args}", payload);
        }
       
        public async Task<HttpResponseMessage> PostAsJsonAsync(string endpoint, object data, string args = null)
        {
            var response = await _httpClient.PostAsJsonAsync($"{endpoint}", data);
            return response;
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
