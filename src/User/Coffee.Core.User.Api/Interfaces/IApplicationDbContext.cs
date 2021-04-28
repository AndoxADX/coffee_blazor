using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Core.User.Api
{
    public interface IApplicationDbContext
    {
        DbSet<IdentityUser> AppUsers { get; set; }

        // DbSet<TodoList> TodoLists { get; set; }

        // DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
