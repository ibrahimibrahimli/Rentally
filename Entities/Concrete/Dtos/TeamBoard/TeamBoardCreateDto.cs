using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeamBoardCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string PositionName { get; set; }

        public static TeamBoard ToTeamboard(TeamBoardCreateDto dto)
        {
            TeamBoard teamBoard = new TeamBoard()
            {
                Name = dto.Name,
                FacebookUrl = dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl,
                LinkedinUrl = dto.LinkedinUrl,
                PinterestUrl = dto.PinterestUrl,
                Surname = dto.Surname,
                ImageUrl = dto.ImageUrl,
                PositionId = dto.PositionId,
            };

            return teamBoard;
        }
    }
}
