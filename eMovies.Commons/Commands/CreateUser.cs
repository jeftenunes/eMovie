using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Commands
{
    public class CreateUser : ICommand
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreateUser(string email, string password, string userName)
        {
            Email = !string.IsNullOrWhiteSpace(email) || !string.IsNullOrEmpty(email) ? 
                email : throw new ArgumentException(nameof(email));
            Password = !string.IsNullOrWhiteSpace(password) || !string.IsNullOrEmpty(password) ?
                password : throw new ArgumentException(nameof(password));
            UserName = !string.IsNullOrWhiteSpace(userName) || !string.IsNullOrEmpty(userName) ?
                userName : throw new ArgumentException(nameof(userName));

            CreatedAt = DateTime.Now;
        }
    }
}