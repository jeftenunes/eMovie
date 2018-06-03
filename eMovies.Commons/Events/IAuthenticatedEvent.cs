using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}
