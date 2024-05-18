using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ImageUrl { get; set; }

        public static Testimonial ToTestimonial( TestimonialDto dto)
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
