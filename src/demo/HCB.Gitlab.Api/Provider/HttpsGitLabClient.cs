using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HCB.Gitlab.Api.Model;
using HCB.Gitlab.Api.v4;

namespace HCB.Gitlab.Api.Provider
{
    public class HttpsGitLabClient : IGitlabClient
    {
        private readonly HttpClient _client;
        private readonly GitlabOptions _options;

        public HttpsGitLabClient(HttpClient client, GitlabOptions options)
        {
            _options = options;
            _client = client;
            // configure Authentication token
            client.DefaultRequestHeaders.Add(options.token.TokenType, options.token.TokenValue);
        }

        // Hidden Implementations
        public Task<HttpResponseMessage> Get(string url) => _client.SendAsync(NewRequest(HttpMethod.Get, null, _options.baseUrl + url));

        public Task<HttpResponseMessage> Post(string url, object model) => _client.SendAsync(NewRequest(HttpMethod.Post, model, _options.baseUrl + url));

        public Task<HttpResponseMessage> Put(string url, object model) => _client.SendAsync(NewRequest(HttpMethod.Put, model, _options.baseUrl + url));

        public Task<HttpResponseMessage> Delete(string url) => _client.SendAsync(NewRequest(HttpMethod.Delete, null, _options.baseUrl + url));

        // Implementations
        public Task<T> Get<T>(string url) => GetJsonResult<T>(Get(url));

        public Task<T> Post<T>(string url, object model) => GetJsonResult<T>(Post(url, model));

        public Task<T> Put<T>(string url, object model) => GetJsonResult<T>(Put(url, model));

        public Task Delete<T>(string url) => GetJsonResult<string>(Delete(url));

        // Helpers
        public static async Task<T> GetJsonResult<T>(Task<HttpResponseMessage> message)
        {
            var result = await message;
            if (result.IsSuccessStatusCode == false)
                throw new ClientErrorException(result.ReasonPhrase, result.StatusCode);
            return await result.Content.ReadFromJsonAsync<T>();
        }
        public static HttpRequestMessage NewRequest(HttpMethod method, object model, string url) => new HttpRequestMessage
        {
            Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json"),
            Method = method,
            RequestUri = new Uri(url)
        };
    }
}