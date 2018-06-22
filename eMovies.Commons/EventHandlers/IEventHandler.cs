using System;
using System.Text;
using eMovie.Commons.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMovie.Commons.EventHandlers
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event); 
    }
}
