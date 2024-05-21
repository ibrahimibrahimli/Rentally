using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class NewValidation : AbstractValidator<New>
    {
        public NewValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UIMessages.MAXIMUM_100_SYMBOL_MESSAGE);

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(2000)
                .WithMessage(UIMessages.MAXIMUM_2000_SYMBOL_MESSAGE);

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(300)
                .WithMessage(UIMessages.MAXIMUM_300_SYMBOL_MESSAGE);
        }
    }
}
