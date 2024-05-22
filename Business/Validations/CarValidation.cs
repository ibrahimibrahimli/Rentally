using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class CarValidation : AbstractValidator<Car>
    {
        public string ImageUrl { get; set; }
        public CarValidation()
        {
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.DoorCount)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .GreaterThanOrEqualTo(1)
                .WithMessage(UIMessages.GREATER_THAN_1);

            RuleFor(x => x.Count)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .GreaterThanOrEqualTo(1)
                .WithMessage(UIMessages.GREATER_THAN_1);

            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .LessThan(x => DateTime.Now).WithMessage(UIMessages.YEAR_LESSTHAN_NOW);

            RuleFor(x => x.PricePerDay)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .GreaterThanOrEqualTo(1)
                .WithMessage(UIMessages.GREATER_THAN_1);
        }
    }
}
