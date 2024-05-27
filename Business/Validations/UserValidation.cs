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
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
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

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .EmailAddress()
                .WithMessage(UIMessages.NOT_VALID_EMAIL);

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MaximumLength(13)
                .WithMessage(UIMessages.NOT_VALID_PHONENUMBER)
                .MaximumLength(13)
                .WithMessage(UIMessages.NOT_VALID_PHONENUMBER);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                   .MinimumLength(8)
                   .WithMessage(UIMessages.PASSWORD_LESS_THAN_LETTER)
                   .MaximumLength(16)
                   .WithMessage(UIMessages.PASSWORD_GREAT_THAN_LETTER)
                   .Matches(@"[a-z]+")
                   .WithMessage(UIMessages.PASSWORD_NOT_CONTAIN_LOWERCASE)
                   .Matches(@"[0-9]+")
                   .WithMessage(UIMessages.PASSWORD_NOT_CONTAIN_NUMBER);
            //.Matches(@"[A-Z]+")
            //.WithMessage(UIMessages.PASSWORD_NOT_CONTAIN_UPPERCASE)
            //.Matches(@"[\!\@\#]+")
            //.WithMessage(UIMessages.PASSWORD_NOT_CONTAIN_SYMBOL);
        }
    }
}
