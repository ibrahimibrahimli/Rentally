using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class NewCreateDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public static New ToNewDto(NewDto dto)
        {
            New news = new New()
            {
                Title = dto.Title,
                Text = dto.Text,
                ImageUrl = dto.ImageUrl,
            };

            return news;
        }
    }
}
