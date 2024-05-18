using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SocialUpdateDto
    {
        public int Id { get; set; }
        public int TeamBoardId { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string TeamBoardName { get; set; }


        public static Social ToSocial(SocialUpdateDto dto)
        {
            Social social = new Social()
            {
                Id = dto.Id,
                TeamBoardId = dto.TeamBoardId,
                FacebookUrl = dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl,
                LinkedinUrl = dto.LinkedinUrl,
                PinterestUrl = dto.PinterestUrl,
            };

            return social;
        }
    }
}
