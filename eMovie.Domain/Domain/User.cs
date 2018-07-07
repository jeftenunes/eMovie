using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Infrastructure.Domain
{
    public class User
    {
        protected User() { }

        public User(string email, string password, string userName)
        {
            Email = !string.IsNullOrWhiteSpace(email) || !string.IsNullOrEmpty(email) ?
                email : throw new ArgumentException(nameof(email));
            Password = !string.IsNullOrWhiteSpace(password) || !string.IsNullOrEmpty(password) ?
                password : throw new ArgumentException(nameof(password));
            UserName = !string.IsNullOrWhiteSpace(userName) || !string.IsNullOrEmpty(userName) ?
                userName : throw new ArgumentException(nameof(userName));

            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
