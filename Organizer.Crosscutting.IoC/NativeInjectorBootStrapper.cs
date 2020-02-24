using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Organizer.Crosscutting.Bus;

namespace Organizer.Crosscutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
            // Domain - Events
            //services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            //services.AddScoped<IRequestHandler<ContactUsFormCommand, bool>, FormCommandHandlers>();
            //services.AddScoped<IRequestHandler<CampaignFormCommand, bool>, CampaignFormCommandHandler>();
            //services.AddScoped<IRequestHandler<MailTemplateCommand, bool>, MailTemplateCommandHandler>();
        }
    }
}