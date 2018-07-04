using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eMovie.Commons.Commands;
using eMovie.Commons.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace eMovie.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                    .UseRabbitMq()
                    .SubscribeToCommand<CreateUser>()
                    .Build()
                    .Run();
        }
    }
}
