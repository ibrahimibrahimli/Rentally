using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class PositionValidation : AbstractValidator<Position>
    {
        public PositionValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);
        }
    }
}
