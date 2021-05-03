using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Core.User.Application
{
    public interface IApplicationDbContext
    {
        // DbSet<ApplicationUser> AppUsers { get; set; } // identity related is 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
