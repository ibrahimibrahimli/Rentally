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
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
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
                FacebookUrl = dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl,
                LinkedinUrl = dto.LinkedinUrl,
                PinterestUrl = dto.PinterestUrl,
            };

            return teamBoard;
        }
    }
}
