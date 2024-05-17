using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CarDal : BaseRepository<Car, ApplicationDbContext>, ICarDal
    {
        ApplicationDbContext context = new();
        public List<Car> GetCarWithCategory()
        {
            var data = context.Cars
                .Where(x => x.Deleted == 0)
                .Include(x => x.CarCategory).ToList();
            return data;
        }
    }

}
