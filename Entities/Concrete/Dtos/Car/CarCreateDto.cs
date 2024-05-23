using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CarCreateDto
    {
        public int Id { get; set; }
        public List<Favourite> Favourites { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CarCategoryId { get; set; }
        public int DoorCount { get; set; }
        public int Count { get; set; }
        public int PassengerCount { get; set; }
        public DateTime Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; }
        public string  CarCategoryName { get; set; }
        public bool IsHomePage { get; set; }

        public static Car ToCar(CarCreateDto dto)
        {
            Car car = new Car()
            {
                Id = dto.Id,
                Favourites = dto.Favourites,
                Brand = dto.Brand,
                Model = dto.Model,
                CarCategoryId = dto.CarCategoryId,
                DoorCount = dto.DoorCount,
                Count = dto.Count,
                PassengerCount = dto.PassengerCount,
                Year = dto.Year,
                PricePerDay = dto.PricePerDay,
                ImageUrl = dto.ImageUrl,
                IsHomePage = dto.IsHomePage,
            };

            return car;
        }
    }
}
