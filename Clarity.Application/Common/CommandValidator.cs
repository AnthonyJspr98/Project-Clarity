using System.Linq;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Clarity.Application.Common
{
    public static class CommandValidator
    {
        public static IServiceCollection AddValidators(this IServiceCollection services, Assembly assembly)    
        {
            var _validatorTypes = assembly.GetTypes()
                .Where(a => a.BaseType != null
                         && a.BaseType.IsGenericType
                         && a.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .Select(a => new
                {
                    Validator = a,
                    IValidator = typeof(IValidator<>)
                        .MakeGenericType
                        (
                            a.BaseType.GetGenericArguments().Single()
                        )
                })
                .ToList();

            foreach (var _validator in _validatorTypes)
            {
                services.AddTransient(_validator.IValidator, _validator.Validator);
            }

            return services;
        }
    }
}