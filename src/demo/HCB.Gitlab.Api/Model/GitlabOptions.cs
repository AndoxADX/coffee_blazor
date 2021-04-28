namespace HCB.Gitlab.Api.Model
{
    public class GitlabOptions
    {
        public GitlabApiToken token { get; init; }
        public string baseUrl { get; init; }

        public GitlabOptions()
        {
            baseUrl = "https://gitlab.com/";
        }
    }
}