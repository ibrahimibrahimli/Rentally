using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class FavouriteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Car> Cars { get; set; }

        public static Favourite ToFavourite(FavouriteDto dto)
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
