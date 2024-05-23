using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(CarCreateDto entity, IFormFile imageUrl, string webRootPath);
        IResult Update(CarUpdateDto entity, IFormFile imageUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<CarDto>> GetCarWithCategory();
        IDataResult<Car> GetById(int id);
    }
}
