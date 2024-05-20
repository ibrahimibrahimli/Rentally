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
    public class UserManager : IUserService
    {
        UserDal userDal = new();

        public IResult Add(UserCreateDto dto)
        {
            var model = UserCreateDto.ToUser(dto);
            userDal.Add(model);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            userDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(userDal.GetById(id));
        }

        public IResult Update(UserUpdateDto dto)
        {
            var model = UserUpdateDto.ToUser(dto);
            model.UpdatedDate = DateTime.Now;
            userDal.Update(model);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        

    }
}
