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
    public class BookingValidation : AbstractValidator<Booking>
    {
        public BookingValidation() 
        {
            RuleFor(x => x.PickUpLocation)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.DropOffLocation)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.DropOffLocation)
                .MaximumLength(200)
                .WithMessage(UIMessages.MAXIMUM_200_SYMBOL_MESSAGE);

            RuleFor(x => x.PickUpDateTime)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .GreaterThan(x => DateTime.Now).WithMessage(UIMessages.PICKUPDATE_GREAT_NOW);

            RuleFor(x => x.DropOffDateTime)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE)
                .GreaterThan(x => x.PickUpDateTime).WithMessage(UIMessages.DROPOFFDATE_GREAT_PICKUPDATE);
        }
    }
}
