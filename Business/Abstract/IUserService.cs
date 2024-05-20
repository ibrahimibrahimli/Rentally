using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(UserCreateDto dto);
        IResult Update(UserUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
    }
}
