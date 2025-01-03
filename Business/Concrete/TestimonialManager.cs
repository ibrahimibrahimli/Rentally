﻿using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
        private readonly IValidator<Testimonial> _validator;

        public TestimonialManager(ITestimonialDal testimonialDal, IValidator<Testimonial> validator)
        {
            _testimonialDal = testimonialDal;
            _validator = validator;
        }
        public IResult Add(TestimonialCreateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = TestimonialCreateDto.ToTestimonial(dto);
            var validator = _validator.Validate(model);
            model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);


            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _testimonialDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(TestimonialUpdateDto dto, IFormFile imageUrl, string webRootPath)
        {
            var model = TestimonialUpdateDto.ToTestimonial(dto);

            var existData = GetById(dto.Id).Data;
            if (imageUrl == null)
            {
                model.ImageUrl = existData.ImageUrl;
            }
            else
            {
                model.ImageUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

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
