using eMovie.Infrastructure;
using eMovie.Infrastructure.Domain;
using eMovie.Infrastructure.Factory;
using eMovie.Services.Catalog.Services.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace eMovie.Services.Catalog.Services
{
    public class MovieService : IMovieService
    {       
        public async Task AddAsync(string url, string title, string duration, string description)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                await context.Movies.AddAsync(new Infrastructure.Domain.Movie(url, title, duration, description));
                await context.SaveChangesAsync();
            }  
        }

        public IEnumerable<Movie> Get()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                return context.Movies.ToList();
            }
        }
    }
}
