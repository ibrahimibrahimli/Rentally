using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ICarDal : IBaseRepository<Car> {
       List<Car> GetCarWithCategory();
    }
}
