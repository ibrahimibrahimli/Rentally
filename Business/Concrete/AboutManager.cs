using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IValidator<About> validator)
        {
            _validator = validator;
            _aboutDal = aboutDal;
        }
        public IResult Add(AboutCreateDto dto)
        {
            About model = AboutCreateDto.ToAbout(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";
            foreach(var error in validator.Errors)                                  
            {
                errorMessage = error.ErrorMessage;
            }

            if(!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _aboutDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

 

        public IDataResult<List<AboutDto>> GetAboutWithCarCustomerBooking()
        {
            return new SuccessDataResult<List<AboutDto>>(_aboutDal.GetAboutWithCarCustomerBooking());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetById(id));
        }

        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);
            model.UpdatedDate = DateTime.Now;
            _aboutDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }
    }
}
