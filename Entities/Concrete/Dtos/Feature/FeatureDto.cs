using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }

        public static Feature ToFeature(FeatureDto dto)
        {
            Feature feature = new Feature()
            {   Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IconName = dto.IconName,
            };

            return feature;
        }
    }
}
