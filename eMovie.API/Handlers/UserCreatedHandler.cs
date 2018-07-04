using eMovie.Commons.EventHandlers;
using eMovie.Commons.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.API.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public async Task HandleAsync(UserCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User Created. { @event.UserName }");
        }
    }
}
