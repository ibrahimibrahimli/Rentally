using Core.Results.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(ContactCreateDto dto);
        IResult Update(ContactUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
    }
}
