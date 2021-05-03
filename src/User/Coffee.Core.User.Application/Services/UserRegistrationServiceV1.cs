using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Core.User.Grpc;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Coffee.Core.User.Application
{
    public class UserRegistrationServiceV1 : UserRegistrationService.UserRegistrationServiceBase
    {
        private readonly ILogger<UserRegistrationServiceV1> _logger;
        private readonly MessageOrchestrator _messageOrchestrator;

        public UserRegistrationServiceV1(ILogger<UserRegistrationServiceV1> logger, MessageOrchestrator messageOrchestrator)
        {
            _logger = logger;
            _messageOrchestrator = messageOrchestrator;
        }

         public override async Task<NewUserResponse> RegisterNewUser(RegNewUserRequest request, ServerCallContext context)
        {
            var userId = await _messageOrchestrator.Send<RegisterUserCommand,string>(request, context);

            return new NewUserResponse { UserId = userId };
        }
    }
}
