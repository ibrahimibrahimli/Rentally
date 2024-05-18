using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Position ToPositionDto(PositionDto dto)
        {
            Position position = new Position()
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return position;
        }
    }
}
