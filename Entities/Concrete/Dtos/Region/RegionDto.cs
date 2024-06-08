using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }

        public static Region ToRegion(RegionDto dto)
        {
            Region region = new Region()
            {
                Id = dto.Id,
                Name = dto.Name,
                PostalCode = dto.PostalCode,
            };

            return region;
        }
    }
}
