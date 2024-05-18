using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestimonialCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ImageUrl { get; set; }

        public static Testimonial ToTestimonial(TestimonialCreateDto dto)
        {
            Testimonial testimonial = new Testimonial()
            {
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
