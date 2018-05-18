using System;
using System.Collections.Generic;
using System.Text;

namespace eMovies.Commons.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Password { get; private set; }
        public string UserName { get; private set; }

        public AuthenticateUser(string password, string userName)
        {
            Password = !string.IsNullOrWhiteSpace(password) || !string.IsNullOrEmpty(password) ?
               password : throw new ArgumentException(nameof(password));
            UserName = !string.IsNullOrWhiteSpace(userName) || !string.IsNullOrEmpty(userName) ?
                userName : throw new ArgumentException(nameof(userName));
        }
    }
}