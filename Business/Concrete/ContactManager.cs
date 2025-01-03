﻿using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _contactDal = contactDal;
            _validator = validator;
        }
        public IResult Add(ContactCreateDto dto)
        {
            var model = ContactCreateDto.ToContact(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _contactDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }
        public IResult Update(ContactUpdateDto dto)
        {
            var model = ContactUpdateDto.ToContact(dto);
            model.UpdatedDate = DateTime.Now;
            _contactDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _contactDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetById(id));
        }

    }
}
