using eMovie.Commons.Commands;
using eMovie.Commons.EventHandlers;
using eMovie.Commons.Events;
using eMovie.Commons.RabbitMq;
using eMovie.Commons.Services.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Commons.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost webHost;

        public ServiceHost(IWebHost webHost)
        {
            this.webHost = webHost;
        }

        public void Run() => webHost.Run();

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();
            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private IBusClient busClient;
            private readonly IWebHost webHost;
            public HostBuilder(IWebHost webHost)
            {
                this.webHost = webHost;
            }

            public BusBuilder UseRabbitMQ()
            {
                busClient = webHost.Services.GetService(typeof(IBusClient)) as IBusClient;
                return new BusBuilder(webHost, busClient);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(webHost);
            }
        }

        public class BusBuilder : BuilderBase
        {
            private IBusClient busClient;
            private readonly IWebHost webHost;
            public BusBuilder(IWebHost webHost, IBusClient busClient)
            {
                this.webHost = webHost;
                this.busClient = busClient;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)webHost.Services
                    .GetService(typeof(TCommand));
                busClient.WithCommandHandlerAsync(handler);

                return this;
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)webHost.Services
                    .GetService(typeof(TEvent));
                busClient.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(webHost);
            }
        }
    }
}
