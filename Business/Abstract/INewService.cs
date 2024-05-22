using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface INewService
    {
        IResult Add(NewCreateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Update(NewUpdateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<New>> GetAll();
        IDataResult<New> GetById(int id);
    }
}
