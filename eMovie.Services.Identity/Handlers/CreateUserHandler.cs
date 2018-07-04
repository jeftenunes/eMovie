using eMovie.Commons.Commands;
using eMovie.Commons.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient busClient;
        public CreateUserHandler(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        public async Task HandleAsync(CreateUser command)
        {
            Console.WriteLine($"Creating user {command.UserName}");
            await busClient.PublishAsync(new UserCreated(command.Email, command.UserName));
        }
    }
}
