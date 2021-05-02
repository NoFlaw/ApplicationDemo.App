using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationDemo.Mvc.Helpers
{
    public interface IHttpClientWrapper
    {
        void Dispose();
        Task<HttpResponseMessage> GetAsync(string url);
        void SetupClient(string baseAddress, string apiKey, string version);
    }
}