using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FavouriteUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Car> Cars { get; set; }

        public static Favourite ToFavourite(FavouriteUpdateDto dto)
        {
            Favourite favourite = new Favourite()
            {
                Id = dto.Id,
                UserId = dto.UserId,
                Cars = dto.Cars,
            };

            return favourite;
        }
    }
}
