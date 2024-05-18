using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FeatureCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

        public static Feature ToFeature(FeatureCreateDto dto)
        {
            Feature feature = new Feature()
            {
                Title = dto.Title,
                Description = dto.Description,
                IconName = dto.IconName,
            };

            return feature;
        }
    }
}
