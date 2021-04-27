using System;
using Xunit;
using System.Net.Http;
using HCB.Gitlab.Api.Model;
using System.Threading.Tasks;
using HCB.Gitlab.Api.Provider;
using HCB.Gitlab.Api.v4.Group;

namespace HCB.Gitlab.Api.Test.v4
{
    public class GroupApiTest : ApiTestBase
    {
        private readonly GroupApi _api;
        public GroupApiTest()
        {
            _api = new GroupApi(_client);
        }

        [Fact]
        public async Task GetGroups()
        {
            try
            {
                var result = await _api.GetGroups();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        [Fact]
        public async Task GetGroup()
        {
            try
            {
                var result = await _api.GetGroup(6441568);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
