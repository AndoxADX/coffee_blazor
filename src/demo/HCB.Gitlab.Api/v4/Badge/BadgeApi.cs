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
using HCB.Gitlab.Api.v4.Group;
using HCB.Gitlab.Api.v4.Badge.Model;

namespace HCB.Gitlab.Api.v4.Badge
{
    public class BadgeApi<T> : ApiBase where T : ApiBase
    {
        private readonly T _api;
        public BadgeApi(IGitlabClient client, T api) : base(client, "/badges")
        {
            _api = api;
        }

        public Task<List<BadgeModel>> GetBadges(int parentId) => GetLists<List<BadgeModel>>(mainUrl(parentId));
        public Task<BadgeModel> GetBadge(int parentId, int badgeId) => GetOne<BadgeModel>(idUrl(parentId, badgeId));
        public Task<BadgeModel> AddBadge(int parentId, BadgeModel model) => AddOne<BadgeModel>(mainUrl(parentId), model);
        public Task<BadgeModel> EditBadge(int parentId, int badgeId, BadgeModel model) => EditOne<BadgeModel>(idUrl(parentId, badgeId), model);
        public Task DeleteBadge(int parentId, int badgeId) => DeleteOne<int>(idUrl(parentId, badgeId));

        public string mainUrl(int parentId) => _api.idUrl(parentId) + base.mainUrl();
        public string idUrl(int parentId, int id) => _api.idUrl(parentId) + base.idUrl(id);
    }
}
