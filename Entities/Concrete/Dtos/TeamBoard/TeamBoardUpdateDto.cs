using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeamBoardUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public static TeamBoard ToTeamboard(TeamBoardUpdateDto dto)
        {
            TeamBoard teamBoard = new TeamBoard()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                ImageUrl = dto.ImageUrl,
                PositionId = dto.PositionId,
            };

            return teamBoard;
        }
    }
}
