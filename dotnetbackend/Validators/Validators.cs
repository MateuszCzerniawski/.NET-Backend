using dotnetbackend.Validators;

namespace dotnetbackend.Validators;
using FluentValidation;

public static class Validators
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<PostSlotRequestModelValidator>();
    }
}