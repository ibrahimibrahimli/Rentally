using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ISliderService
    {
        IResult Add(SliderCreateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Update(SliderUpdateDto dto, IFormFile imageUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Slider>> GetAll();
        IDataResult<Slider> GetById(int id);
    }
}
