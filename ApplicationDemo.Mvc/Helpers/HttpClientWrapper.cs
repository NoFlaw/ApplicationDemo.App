using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationDemo.Mvc.Helpers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();            
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public void SetupClient(string baseAddress, string apiKey, string version)
        {
            if (!string.IsNullOrEmpty(baseAddress))
                _httpClient.BaseAddress = new Uri(baseAddress);

            if (!string.IsNullOrEmpty(apiKey))
                _httpClient.DefaultRequestHeaders.Add("APIKey", apiKey);

            if (!string.IsNullOrEmpty(version))
                _httpClient.DefaultRequestHeaders.Add("X-Version", version);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
