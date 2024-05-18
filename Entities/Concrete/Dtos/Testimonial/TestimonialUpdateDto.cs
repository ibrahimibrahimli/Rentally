using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestimonialUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ImageUrl { get; set; }

        public static Testimonial ToTestimonial(TestimonialUpdateDto dto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                CustomerName = dto.CustomerName,
                CustomerSurname = dto.CustomerSurname,
                ImageUrl = dto.ImageUrl,
            };
            return testimonial;
        }
    }
}
