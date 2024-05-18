using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeamBoardCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public static TeamBoard ToTeamboard(TeamBoardCreateDto dto)
        {
            TeamBoard teamBoard = new TeamBoard()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                ImageUrl = dto.ImageUrl,
                PositionId = dto.PositionId,
            };

            return teamBoard;
        }
    }
}
