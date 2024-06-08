using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class RegionCreateDto
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }

        public static Region ToRegion(RegionCreateDto dto)
        {
            Region region = new Region()
            {
                Name = dto.Name,
                PostalCode = dto.PostalCode,
            };

            return region;
        }
    }
}
