using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CarCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconName { get; set; }

        public static CarCategory ToCarCategory(CarCategoryUpdateDto dto)
        {
            CarCategory carCategory = new CarCategory()
            {
                Id = dto.Id,
                Title = dto.Title,
                IconName = dto.IconName,
            };

            return carCategory;
        }
    }
}
