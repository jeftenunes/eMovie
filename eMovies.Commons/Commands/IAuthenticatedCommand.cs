using System;
using System.Collections.Generic;
using System.Text;

namespace eMovies.Commons.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
