using eMovie.Commons.EventHandlers;
using eMovie.Commons.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.API.Handlers
{
    public class MovieCreatedHandler : IEventHandler<MovieCreated>
    {
        public async Task HandleAsync(MovieCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Movie Created. { @event.Title }");
        }
    }
}
