using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationDemo.Data.Models;
using ApplicationDemo.Mvc.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApplicationDemo.Mvc.Services
{
    public class ContactService : IContactService, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientWrapper _httpClient;
        private const string _baseAddress = "http://localhost:5000";

        public ContactService(IHttpClientWrapper httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            SetupClient();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }

        private void SetupClient()
        {
            string baseAddress = string.IsNullOrEmpty(_configuration["WebApiServer"]) ? _baseAddress : _configuration["WebApiServer"];
            _httpClient.SetupClient(baseAddress, _configuration["APIKey"], _configuration["X-Version"]);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
