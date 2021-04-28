namespace HCB.Gitlab.Api.Model
{
    public class GitlabApiToken
    {
        public string TokenType { get; init; }
        public string TokenValue { get; init; }

        public GitlabApiToken(string TokenType, string TokenValue)
        {
            this.TokenType = TokenType;
            this.TokenValue = TokenValue;
        }
    }
}