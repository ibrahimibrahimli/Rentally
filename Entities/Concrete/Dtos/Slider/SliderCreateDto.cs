using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public static Slider ToPosition(SliderCreateDto dto)
        {
            Slider slider = new Slider()
            {
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };

            return slider;
        }
    }
}
