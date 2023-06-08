using BP.Service.DTOs.WeightDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BP.Api.Extensions
{
    public static class FluentValidationKeeper
    {
        public static void FluentValidatorBuilder(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<WeightPostDTO>();
        }
    }
}
