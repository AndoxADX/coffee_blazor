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

namespace HCB.Gitlab.Api.v4.Project
{
    public class ProjectApi : ApiBase
    {
        public ProjectApi(IGitlabClient client) : base(client, "api/v4/projects")
        {
        }
    }
}
