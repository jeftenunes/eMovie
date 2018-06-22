using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMovie.Commons.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
