using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; private set; }
        public string UserName { get; private set; }

        //Protected constructor to be used to SignalR
        protected UserCreated() { }

        public UserCreated(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}
