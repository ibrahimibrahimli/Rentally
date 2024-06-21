using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CarDal : BaseRepository<Car, ApplicationDbContext>, ICarDal
    {
        private readonly ApplicationDbContext _context;

        public CarDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<CarDto> GetCarWithCategory()
        {

            var result = from car in _context.Cars
                         where car.Deleted == 0
                         join carCategory in _context.CarCategories on car.CarCategoryId equals carCategory.Id
                         where carCategory.Deleted == 0
                         select new CarDto
                         {
                             Id = car.Id,
                             Brand = car.Brand,
                             Model = car.Model,
                             CarCategoryId = car.CarCategoryId,
                             DoorCount = car.DoorCount,
                             Year = car.Year,
                             Count = car.Count,
                             PricePerDay = car.PricePerDay,
                             ImageUrl = car.ImageUrl,
                             CarCategoryName = carCategory.Title,
                             IsHomePage = car.IsHomePage,
                             PassengerCount = car.PassengerCount,
                         };

            return result.ToList();
        }
    }

}
