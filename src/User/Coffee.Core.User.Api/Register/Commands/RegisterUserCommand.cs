using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Core.User.Api
{
    public class RegisterUserCommand : IRequest<string>
    {

         public string UserId { get; set; }

        public string Name { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private readonly IApplicationDbContext _context;

        public RegisterUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser{
                Email = "Temp1",
                UserName = request.Name,
                Id = request.UserId
            };


            // _context.AppUsers.Add(user);
            // await _userManager.CreateAsync();
            // await _identityService
            await _context.SaveChangesAsync(cancellationToken);
            return user.UserName;
        }

    }
}
