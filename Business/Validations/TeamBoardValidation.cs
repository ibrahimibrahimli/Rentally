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
    public class TeamBoardValidation : AbstractValidator<TeamBoard>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string PositionName { get; set; }
        public TeamBoardValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.FacebookUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.LinkedinUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.TwitterUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.PinterestUrl)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);
        }
    }
}
