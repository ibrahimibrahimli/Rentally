using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FeatureUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

        public static Feature ToFeature(FeatureUpdateDto dto)
        {
            Feature feature = new Feature()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IconName = dto.IconName,
            };

            return feature;
        }
    }
}
