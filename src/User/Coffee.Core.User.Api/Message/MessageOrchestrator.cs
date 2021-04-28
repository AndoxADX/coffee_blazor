using System;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Coffee.Core.User.Api
{
    public class MessageOrchestrator
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<MessageOrchestrator> logger;

        public MessageOrchestrator(IServiceProvider serviceProvider, ILogger<MessageOrchestrator> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task<Unit> Send<TCommand>(IMessage request, ServerCallContext context)
            where TCommand : IRequest<Unit>
        {
            return await Send<TCommand, Unit>(request, context);
        }

        public async Task<TResponse> Send<TCommand, TResponse>(IMessage request, ServerCallContext context)
            where TCommand : IRequest<TResponse>
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                // var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var sender = scope.ServiceProvider.GetRequiredService<ISender>();

                var command = mapper.Map<TCommand>(request);

                logger.LogDebug($"{Environment.NewLine} MediatR request method: {context.Method}{Environment.NewLine}");

                // var response = await mediator.Send(request);
                var response = await sender.Send(command);

                logger.LogDebug($"{Environment.NewLine} MediatR response received in method: {context.Method}{Environment.NewLine}");

                return response;
            }
        }
    }
}
