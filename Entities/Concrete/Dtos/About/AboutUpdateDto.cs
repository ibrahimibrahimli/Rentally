using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompletedOrders { get; set; }
        public int Customers { get; set; }
        public int Cars { get; set; }

        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new About()
            {
                Id = dto.Id,
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
