using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class CarDto
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
    }
}
