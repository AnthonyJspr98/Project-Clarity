using System.Reflection;
using AutoMapper;
using Clarity.Application.Common;
using Clarity.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Clarity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, bool includeValidators = false)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            if (includeValidators)
            {
                services.AddValidators(Assembly.GetExecutingAssembly());
            }

            return services;
        }
    }
}