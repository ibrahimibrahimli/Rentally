using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class NewUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public static New ToNew(NewUpdateDto dto)
        {
            New news = new New()
            {
                Id = dto.Id,
                Title = dto.Title,
                Text = dto.Text,
                ImageUrl = dto.ImageUrl,
            };

            return news;
        }
    }
}
