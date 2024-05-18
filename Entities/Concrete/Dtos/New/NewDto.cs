using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class NewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public static New ToNewDto(NewDto dto)
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
