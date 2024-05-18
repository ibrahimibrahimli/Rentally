using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CarUpdateDto
    {
        public int Id { get; set; }
        public List<Favourite> Favourites { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CarCategoryId { get; set; }
        public int DoorCount { get; set; }
        public int Count { get; set; }
        public DateTime Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; }
        public string  CarCategoryName { get; set; }

        public static Car ToCarCategory(CarUpdateDto dto)
        {
            Car car = new Car()
            { 
                Favourites = dto.Favourites,
                Brand = dto.Brand,
                Model = dto.Model,
                CarCategoryId = dto.CarCategoryId,
                DoorCount = dto.DoorCount,
                Count = dto.Count,
                Year = dto.Year,
                PricePerDay = dto.PricePerDay,
                ImageUrl = dto.ImageUrl,                
            };

            return car;
        }
    }
}
