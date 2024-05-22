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
    public class SliderValidation : AbstractValidator<Slider>
    {
        public SliderValidation()
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
                .MaximumLength(500)
                .WithMessage(UIMessages.MAXIMUM_500_SYMBOL_MESSAGE);

            //RuleFor(x => x.ImageUrl)
            //    .NotEmpty()
            //    .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
            //    .MinimumLength(3)
            //    .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
            //    .MaximumLength(200)
            //    .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);
        }
    }
}
