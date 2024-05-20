using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SliderUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public static Slider ToSlider(SliderUpdateDto dto)
        {
            Slider slider = new Slider()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };

            return slider;
        }
    }
}
