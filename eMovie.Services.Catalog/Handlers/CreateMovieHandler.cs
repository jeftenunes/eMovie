using eMovie.Commons.Commands;
using eMovie.Commons.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Services.Catalog.Handlers
{
    public class CreateMovieHandler : ICommandHandler<CreateMovie>
    {
        private readonly IBusClient busClient;
        public CreateMovieHandler(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        public async Task HandleAsync(CreateMovie command)
        {
            Console.WriteLine($"Creating movie {command.Title}");
            await busClient.PublishAsync(new MovieCreated(command.Id, command.Title));
        }
    }
}
