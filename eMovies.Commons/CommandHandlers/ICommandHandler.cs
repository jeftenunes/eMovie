using System;
using System.Text;
using eMovies.Commons.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMovies.Commons.CommandHandlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
