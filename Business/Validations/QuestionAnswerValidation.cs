using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class QuestionAnswerValidation : AbstractValidator<QA>
    {
        public QuestionAnswerValidation()
        {
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.Answer)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(10000)
                .WithMessage(UIMessages.MAXIMUM_1000_SYMBOL_MESSAGE);

        }
    }
}
