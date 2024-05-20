using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompletedOrders { get; set; }
        public int Customers { get; set; }
        public int Cars { get; set; }

        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new About()
            {
                Title = dto.Title,
                Description = dto.Description,
                CompletedOrders = dto.CompletedOrders,
                Customers = dto.Customers,
                Cars = dto.Cars,
            };

            return about;
        }
    }
}
