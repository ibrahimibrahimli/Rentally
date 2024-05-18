using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ICarDal : IBaseRepository<Car> {
       List<CarDto> GetCarWithCategory();
    }
}
