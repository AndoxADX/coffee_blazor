using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HCB.Gitlab.Api.Model;
using HCB.Gitlab.Api.v4.Group.Model;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using HCB.Gitlab.Api.v4;
using HCB.Gitlab.Api.Provider;

namespace HCB.Gitlab.Api.v4
{
    public abstract class ApiBase
    {
        private readonly IGitlabClient _client;

        public readonly string _restUrl;

        public ApiBase(IGitlabClient client, string restUrl)
        {
            _client = client;
            _restUrl = restUrl;
        }

        public virtual string mainUrl() => _restUrl;
        public virtual string idUrl(int id) => $"{_restUrl}/{id}";

        public Task<T> GetLists<T>(string url) => _client.Get<T>(url);
        public Task<T> GetOne<T>(string url) => _client.Get<T>(url);
        public Task<T> AddOne<T>(string url, object model) => _client.Post<T>(url, model);
        public Task<T> EditOne<T>(string url, object model) => _client.Put<T>(url, model);
        public Task DeleteOne<T>(string url) => _client.Delete<T>(url);
    }
}
