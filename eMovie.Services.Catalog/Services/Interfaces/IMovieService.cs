using eMovie.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Services.Catalog.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> Get();
        Task AddAsync(string url, string title, string duration, string description);
    }
}
