using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Events
{
    public class UserAuthenticated : IEvent
    {
        public string Email { get;  }
        public string UserName { get; }
        
        //Protected constructor to be used to SignalR
        protected UserAuthenticated() { }

        public UserAuthenticated(string email, string userName)
        {

        }
    }
}
