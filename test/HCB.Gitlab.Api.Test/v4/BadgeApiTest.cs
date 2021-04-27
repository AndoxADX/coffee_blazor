using System;
using Xunit;
using System.Net.Http;
using HCB.Gitlab.Api.Model;
using System.Threading.Tasks;
using HCB.Gitlab.Api.Provider;
using HCB.Gitlab.Api.v4.Group;
using HCB.Gitlab.Api.v4.Badge;
using HCB.Gitlab.Api.v4.Project;
using HCB.Gitlab.Api.v4.Badge.Model;

namespace HCB.Gitlab.Api.Test.v4
{
    public class BadgeApiTest : ApiTestBase
    {
        private readonly BadgeApi<ProjectApi> _api;
        public BadgeApiTest()
        {
            _api = new(_client, new ProjectApi(_client));
        }

        [Fact]
        public async Task GetGroupBadges()
        {
            try
            {
                var result = await _api.GetBadges(23086109);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        [Fact]
        public async Task DeleteBadges()
        {
            try
            {
                await _api.DeleteBadge(23086109, 131359);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        [Fact]
        public async Task AddBadges()
        {
            try
            {
                // "https://img.shields.io/badge/PIC-Raymond-blue";
                var result = await _api.AddBadge(23086109, new BadgeModel()
                {
                    image_url = "https://img.shields.io/badge/PIC-Raymond-blue",
                    link_url = "https://img.shields.io/badge/PIC-Raymond-blue"
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        [Fact]
        public async Task EditBadges()
        {
            try
            {
                // "https://img.shields.io/badge/PIC-Raymond-blue";
                var result = await _api.EditBadge(23086109, 131361, new BadgeModel()
                {
                    image_url = "https://img.shields.io/badge/PIC-Raymond-blue",
                    link_url = "https://img.shields.io/badge/PIC-Raymond-blue"
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
