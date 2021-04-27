using System.Threading.Tasks;

namespace HCB.Gitlab.Api.Provider
{
    public interface IGitlabClient
    {
        Task<T> Get<T>(string url);

        Task<T> Post<T>(string url, object model);

        Task<T> Put<T>(string url, object model);

        Task Delete<T>(string url);
    }
}