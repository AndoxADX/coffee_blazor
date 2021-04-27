using System;

namespace HCB.Gitlab.Api.v4.Group.Model
{
    public class GroupModel
    {
        public GroupModel()
        {

        }
        public int id { get; init; } //: 1,
        public string name { get; init; } // : "Foobar Group",
        public string path { get; init; } //: "foo-bar",
        public string description { get; init; } //: "An interesting group",
        public string visibility { get; init; } //: "public",
        public bool share_with_group_lock { get; init; } //: false,
        public bool require_two_factor_authentication { get; init; } //: false,
        public int two_factor_grace_period { get; init; } //: 48,
        public string project_creation_level { get; init; } //: "developer",
        // public string auto_devops_enabled {get;init;} //: null,
        public string subgroup_creation_level { get; init; } //: "owner",
        // public string emails_disabled {get;init;} //: null,
        // public string mentions_disabled {get;init;} //: null,
        // public bool lfs_enabled {get;init;} //: true,
        public int default_branch_protection { get; init; } //: 2,
        public string avatar_url { get; init; } //: "http://localhost:3000/uploads/group/avatar/1/foo.jpg",
        public string web_url { get; init; } //: "http://localhost:3000/groups/foo-bar",
        public bool request_access_enabled { get; init; } //: false,
        public string full_name { get; init; } //: "Foobar Group",
        public string full_path { get; init; } //: "foo-bar",
        public int file_template_project_id { get; init; } //: 1,
        public int? parent_id { get; init; } //: null,
        public DateTime created_at { get; init; } //: "2020-01-15T12:36:29.590Z"
    }
}