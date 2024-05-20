using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class TeamBoard : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int PositionId { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string PinterestUrl { get; set; }
        public virtual Position Position { get; set; }
    }

}
