using Coffee.Core.User.Application;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Coffee.Core.User.Infrastructure
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}