using eMovie.Commons.Commands;
using eMovie.Commons.Events;
using eMovie.Services.Catalog.Services.Interfaces;
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
        private readonly IMovieService movieService;
        public CreateMovieHandler(IBusClient busClient, IMovieService movieService)
        {
            this.busClient = busClient;
            this.movieService = movieService;
        }

        public async Task HandleAsync(CreateMovie command)
        {
            Console.WriteLine($"Creating movie {command.Title}");
            try
            {
                await movieService.AddAsync(command.Url, command.Title, command.Duration, command.Description);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await busClient.PublishAsync(new MovieCreated(command.Id, command.Title));
        }
    }
}
