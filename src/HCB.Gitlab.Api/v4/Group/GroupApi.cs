﻿using System;
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

namespace HCB.Gitlab.Api.v4.Group
{
    public class GroupApi: ApiBase
    {
        public GroupApi(IGitlabClient client) : base(client, "api/v4/groups")
        {
        }

        public Task<List<GroupModel>> GetGroups() => GetLists<List<GroupModel>>(mainUrl());
        public Task<GroupModel> GetGroup(int groupId) => GetOne<GroupModel>(idUrl(groupId));
    }
}
