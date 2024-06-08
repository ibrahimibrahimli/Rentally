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
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(50)
                .WithMessage(UIMessages.MAXIMUM_50_SYMBOL_MESSAGE)
                .EmailAddress()
                .WithMessage(UIMessages.NOT_VALID_EMAIL);

            //RuleFor(x => x.PhoneNumber)
            //    .NotEmpty()
            //    .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
            //    .MaximumLength(13)
            //    .WithMessage(UIMessages.NOT_VALID_PHONENUMBER)
            //    .MinimumLength(13)
            //    .WithMessage(UIMessages.NOT_VALID_PHONENUMBER);

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_2000_SYMBOL_MESSAGE);
        }
    }
}
