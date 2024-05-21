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
    public class FeatureValidation : AbstractValidator<Feature>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public FeatureValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(100)
                .WithMessage(UIMessages.MAXIMUM_100_SYMBOL_MESSAGE);

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(2000)
                .WithMessage(UIMessages.MAXIMUM_2000_SYMBOL_MESSAGE);

            RuleFor(x => x.IconName)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);
        }
    }
}
