using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public IResult Add(TestimonialCreateDto dto)
        {
            var model = TestimonialCreateDto.ToTestimonial(dto);
            _testimonialDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(TestimonialUpdateDto dto)
        {
            var model = TestimonialUpdateDto.ToTestimonial(dto);
            model.UpdatedDate = DateTime.Now;
            _testimonialDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _testimonialDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.GetById(id));
        }
    }
}
