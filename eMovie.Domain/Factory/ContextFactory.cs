using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eMovie.Infrastructure.Factory
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<Context>();
            var connectionString = configuration.GetConnectionString("eMovieContext");
            builder.UseSqlServer(connectionString);

            return new Context(builder.Options);
        }

        public static Context CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<Context>();
            var connectionString = configuration.GetConnectionString("eMovieContext");
            builder.UseSqlServer(connectionString);

            return new Context(builder.Options);
        }
    }
}
