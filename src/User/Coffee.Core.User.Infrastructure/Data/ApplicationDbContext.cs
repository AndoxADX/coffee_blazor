
using Coffee.Core.User.Application;
using Coffee.Core.User.Domain;
using IdentityServer4.EntityFramework.Options;
// using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Core.User.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        // private readonly IDateTime _dateTime;
        // private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService
            // IDomainEventService domainEventService,
            // IDateTime dateTime
            ) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            // _domainEventService = domainEventService;
            // _dateTime = dateTime;
        }

        public DbSet<ApplicationUser> AppUsers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            // await DispatchEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        // not using. Could be used for logging domain entities.
        // private async Task DispatchEvents()
        // {
        //     while (true)
        //     {
        //         var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
        //             .Select(x => x.Entity.DomainEvents)
        //             .SelectMany(x => x)
        //             .Where(domainEvent => !domainEvent.IsPublished)
        //             .FirstOrDefault();
        //         if (domainEventEntity == null) break;

        //         domainEventEntity.IsPublished = true;
        //         await _domainEventService.Publish(domainEventEntity);
        //     }
        // }
    }
}
