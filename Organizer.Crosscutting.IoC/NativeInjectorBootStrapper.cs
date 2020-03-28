using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Organizer.Application.Interfaces;
using Organizer.Crosscutting.Bus;
using Organizer.Data.Context;
using Organizer.Data.UoW;
using Organizer.Domain.Core.Notifications;
using Organizer.Domain.Interfaces;

namespace Organizer.Crosscutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.Scan(p =>
                p.FromAssembliesOf(typeof(IApplicationService))
                    .AddClasses(classes => classes.AssignableTo(typeof(IApplicationService)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

            services.Scan(p =>
                p.FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ApplicationDbContext>();

            services.AddSingleton<SemaphoreSlim>(provider => new SemaphoreSlim(1, 1));
            services.AddLogging(builder => builder.AddConsole());
        }
    }
}