using System;
using Xunit;
using System.Net.Http;
using HCB.Gitlab.Api.Model;
using System.Threading.Tasks;
using HCB.Gitlab.Api.Provider;
using HCB.Gitlab.Api.v4.Group;

namespace HCB.Gitlab.Api.Test.v4
{
    public class ApiTestBase
    {
        protected readonly HttpsGitLabClient _client = new HttpsGitLabClient(new HttpClient(), new GitlabOptions
        {
            token = new GitlabApiToken("PRIVATE-TOKEN", "Gep9Z8sQHDaHFk5XuE3u")
        });
    }
}
