using FluentValidation;
using dotnetbackend.RequestModels;

namespace dotnetbackend.Validators;

public class PostSlotRequestModelValidator : AbstractValidator<PostSlotRequestModel>
{
    public PostSlotRequestModelValidator()
    {
        RuleFor(e => e.itemIds).NotNull().NotEmpty();
        RuleForEach(e => e.itemIds).NotNull();
    }
}