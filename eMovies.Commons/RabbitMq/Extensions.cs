using eMovie.Commons.Commands;
using eMovie.Commons.EventHandlers;
using eMovie.Commons.Events;
using RawRabbit;
using RawRabbit.Pipe;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eMovie.Commons.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient busClient,
            ICommandHandler<TCommand> handler) where TCommand : ICommand =>
                busClient.SubscribeAsync<TCommand>(message => handler.HandleAsync(message),
                    context => context.UseConsumerConfiguration(config => config.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient busClient,
           IEventHandler<TEvent> handler) where TEvent : IEvent =>
               busClient.SubscribeAsync<TEvent>(message => handler.HandleAsync(message),
                   context => context.UseConsumerConfiguration(config => config.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>() =>
            $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}
