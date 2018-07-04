using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Events
{
    public class MovieCreated : IEvent
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        protected MovieCreated() { }

        public MovieCreated(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
