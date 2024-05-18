using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FavouriteCreateDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Car> Cars { get; set; }

        public static Favourite ToFavourite(FavouriteCreateDto dto)
        {
            Favourite favourite = new Favourite()
            {
                UserId = dto.UserId,
                Cars = dto.Cars,
            };

            return favourite;
        }
    }
}
