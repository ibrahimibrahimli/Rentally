using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class PositionCreateDto
    {
        public string Name { get; set; }

        public static Position ToPositionDto(PositionDto dto)
        {
            Position position = new Position()
            {
                Name = dto.Name
            };

            return position;
        }
    }
}
