namespace HCB.Gitlab.Api.v4.Badge.Model
{
    public class BadgeModel
    {
        public string name { get; set; } //: "Coverage",
        public int id { get; set; } //: 1,
        public string link_url { get; set; } //: "http://example.com/ci_status.svg?project=%{project_path}&ref=%{default_branch}",
        public string image_url { get; set; } //: "https://shields.io/my/badge",
        public string rendered_link_url { get; set; } //: "http://example.com/ci_status.svg?project=example-org/example-project&ref=master",
        public string rendered_image_url { get; set; } //: "https://shields.io/my/badge",
        public string kind { get; set; } //: "group"

    }
}