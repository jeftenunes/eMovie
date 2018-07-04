﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Commands
{
    public class CreateMovie : ICommand
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public string Title { get; private set; }
        public string Duration { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreateMovie(string url, string title, string duration, string description)
        {
            Url = !string.IsNullOrWhiteSpace(url) || !string.IsNullOrEmpty(url) ?
                url : throw new ArgumentException(nameof(url));
            Title = !string.IsNullOrWhiteSpace(title) || !string.IsNullOrEmpty(title) ?
                title : throw new ArgumentException(nameof(title));
            Duration = !string.IsNullOrWhiteSpace(duration) || !string.IsNullOrEmpty(duration) ?
                duration : throw new ArgumentException(nameof(duration));
            Description = !string.IsNullOrWhiteSpace(description) || !string.IsNullOrEmpty(description) ?
                description : throw new ArgumentException(nameof(description));

            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
