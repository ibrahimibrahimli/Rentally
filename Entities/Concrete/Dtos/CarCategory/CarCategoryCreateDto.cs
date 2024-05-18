using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CarCategoryCreateDto
    {
        public string Title { get; set; }
        public string IconName { get; set; }


        public static CarCategory ToCarCategory(CarCategoryCreateDto dto)
        {
            CarCategory carCategory = new CarCategory()
            {
                Title = dto.Title,
                IconName = dto.IconName,
            };

            return carCategory;
        }
    }
}
